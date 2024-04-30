namespace AuditManagement.DTOs.Audit
{
    public class TransactionDto
    {
        public long Id { get; set; }
        public long AuditTransactionId { get; set; }
        public string ToCurr { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? DaytonaUSDBase { get; set; }
        public int PartnerStatus { get; set; }
    }
}
