namespace AuditManagement.Business.Interfaces
{
    public interface IAuditManager
    {
        Task<int> InsertTransactionDataAsync(string filePath);
        Task<(bool IsSuccess, string? errorMessage)> PostSAPTransactions();
    }
}
