using AuditManagement.DTOs.Audit;
using AuditManagement.Models;

namespace AuditManagement.DataAcces.Repository.Interfaces
{
    public interface IAuditTransactionRepository : IRepository<AuditTransaction>
    {
        Task SaveChangesAsync();
        Task<int> TotalRecordsAsync();
        Task<IEnumerable<TransactionDto>> GetSAPTransactions(int start, int takeCount);
    }
}
