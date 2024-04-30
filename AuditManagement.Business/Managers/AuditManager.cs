using AuditManagement.Business.Interfaces;
using AuditManagement.Business.Maps;
using AuditManagement.DataAcces.Repository.Interfaces;
using AuditManagement.DTOs.Audit;
using AuditManagement.Models;
using CsvHelper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Polly;
using Polly.Retry;
using System.Globalization;
using System.Net;

namespace AuditManagement.Business.Managers
{
    public class AuditManager : IAuditManager
    {
        private readonly IAuditTransactionRepository transactionRepository;
        private readonly IRestApiManager restApiManager;
        private readonly ILogger<AuditManager> logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> retryPolicy;

        public AuditManager(IAuditTransactionRepository transactionRepository, IRestApiManager restApiManager, ILogger<AuditManager> logger)
        {
            this.transactionRepository = transactionRepository;
            this.restApiManager = restApiManager;
            this.logger = logger;
            this.retryPolicy = GetSAPApiRetryPolicy();
        }

        public async Task<(bool IsSuccess, string? errorMessage)> PostSAPTransactions()
        {
            var totalRecords = await transactionRepository.TotalRecordsAsync();
            var startDBIndex = 0;

            while (startDBIndex < totalRecords)
            {
                var transactionList = await transactionRepository.GetSAPTransactions(startDBIndex, AuditConstants.AuditRetrieveBatchSize);
                startDBIndex += transactionList.Count();

                if (transactionList.Count() == 0)
                {
                    break;
                }

                (var isSuccess, var errorMessage) = await PostRecords(transactionList.Select(trans => new SAPAuditDto(trans)));
                if(!isSuccess)
                {
                    return (isSuccess, errorMessage);   
                }
            }

            if (startDBIndex != totalRecords)
            {
                var message = "Records missing. SAP post will not be performed.";
                logger.LogError(message);
                return (false, message);
            }

            return (true, null);
        }

        private async Task<(bool IsSuccess, string? errorMessage)> PostRecords(IEnumerable<SAPAuditDto> allTransactionData)
        {
            int start = 0;
            var dataPostedTOSAP = new List<SAPAuditDto>();
            var totalRecords = allTransactionData.Count();

            while (start < totalRecords)
            {
                var dataToPost = allTransactionData.Skip(start).Take(AuditConstants.SAPBatchSize);
                var response = await retryPolicy.ExecuteAsync(async () => await restApiManager.PostSAPDataAsync(dataToPost));

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = $"Request failed with status '{response.StatusCode}'";
                    logger.LogError($"{errorMessage}.Failed post batch Audit Transaction ID range is: {dataToPost.First().TransactionID} - {dataToPost.Last().TransactionID}");
                    return (false, errorMessage);
                }

                if (dataToPost.Count() == 0)
                {
                    break;
                }

                dataPostedTOSAP.AddRange(dataToPost);
                start = dataPostedTOSAP.Count();

            }

            if (dataPostedTOSAP.Count() != totalRecords)
            {
                var message = "Records missing. SAP post will not be performed.";
                logger.LogError($"{message}. Db Ids posted: {dataPostedTOSAP.First().TransactionID} - {dataPostedTOSAP.Last().TransactionID}");
                return (false, message);
            }

            return (true, null);
        }

        public async Task<int> InsertTransactionDataAsync(string filePath)
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
            config.HeaderValidated = null;
            config.MissingFieldFound = null;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.TypeConverterCache.AddConverter<decimal>(new NullDecimalConverter());
                csv.Context.RegisterClassMap<AuditTransactionMap>();

                var records = csv.GetRecords<AuditTransaction>();

                int batchToProcessCount = 0;
                var recordsToDb = new List<AuditTransaction>();
                int rowsAddedToDB = 0;
                foreach (var record in records)
                {
                    batchToProcessCount++;
                    recordsToDb.Add(record);

                    if (batchToProcessCount == AuditConstants.FileInsertBatchSize)
                    {
                        var rowsInserted = await transactionRepository.ExecuteBulkInsertAsync(recordsToDb);
                        if (!rowsInserted.IsNullOrEmpty())
                        {
                            rowsAddedToDB += rowsInserted.Count();
                        }
                        batchToProcessCount = 0;
                        recordsToDb = new List<AuditTransaction>();
                    }
                }

                if (!recordsToDb.IsNullOrEmpty())
                {
                    var rowsInserted = await transactionRepository.ExecuteBulkInsertAsync(recordsToDb);
                    if (!rowsInserted.IsNullOrEmpty())
                    {
                        rowsAddedToDB += rowsInserted.Count();
                    }
                }

                await transactionRepository.SaveChangesAsync();

                return rowsAddedToDB;
            }
        }

        private AsyncRetryPolicy<HttpResponseMessage> GetSAPApiRetryPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode != HttpStatusCode.OK)
              .Or<HttpRequestException>()
              .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
        }
    }
}
