using AuditManagement.DataAcces.Data;
using AuditManagement.DataAcces.Repository.Interfaces;
using AuditManagement.DTOs.Audit;
using AuditManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AuditManagement.DataAcces.Repository
{
    public class AuditTransactionRepository : Repository<AuditTransaction>, IAuditTransactionRepository
    {
        private readonly ApplicationDbContext db;

        public AuditTransactionRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TransactionDto>> GetSAPTransactions(int start, int takeCount)
        {
            return await db.Transactions.Select(audit => new TransactionDto
            {
                Id = audit.Id,
                AuditTransactionId = audit.AuditTransactionId,
                ToCurr = audit.ToCurr,
                ConfirmedDate = audit.ConfirmedDate,
                TotalAmount = audit.TotalAmount,
                DaytonaUSDBase = audit.DaytonaUSDBase,
                PartnerStatus = audit.PartnerStatus,
            }).OrderBy(x=>x.AuditTransactionId)
            .Skip(start)
            .Take(takeCount).ToListAsync();
        }

        public async Task<int> TotalRecordsAsync()
        {
            return await db.Transactions.CountAsync();
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
