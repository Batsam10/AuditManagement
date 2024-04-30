using AuditManagement.Business.Interfaces;
using AuditManagement.DTOs.Audit;
using System.Text.Json;
using System.Web;

namespace AuditManagement.Business.Managers
{
    public class RestApiManager: IRestApiManager
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RestApiManager(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> PostSAPDataAsync(IEnumerable<SAPAuditDto> transactionData)
        {
            var client = httpClientFactory.CreateClient(AuditConstants.HttpClientName);
            var data = JsonSerializer.Serialize(transactionData);
            return await client.PostAsync(HttpUtility.UrlPathEncode("post"), new StringContent(data));
        }
    }
}
