using AuditManagement.DTOs.Audit;

namespace AuditManagement.Business.Interfaces
{
    public interface IRestApiManager
    {
        Task<HttpResponseMessage> PostSAPDataAsync(IEnumerable<SAPAuditDto> transactionData);
    }
}
