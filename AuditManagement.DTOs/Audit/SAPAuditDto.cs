using AuditManagement.Models;

namespace AuditManagement.DTOs.Audit
{
    public class SAPAuditDto
    {
        public SAPAuditDto(TransactionDto audit)
        {
            TransactionID = audit.Id;
            LineNumber = audit.AuditTransactionId;
            Currency = audit.ToCurr;
            PostDate = audit.ConfirmedDate.ToString("yyyy-MM-dd");
            FCDebit = audit.PartnerStatus == 5000 && audit.TotalAmount != null && audit.DaytonaUSDBase != null ? audit.DaytonaUSDBase * audit.TotalAmount : null;
            FCCredit = audit.PartnerStatus == 5005 && audit.TotalAmount != null && audit.DaytonaUSDBase != null ? audit.DaytonaUSDBase * audit.TotalAmount : null;
            Credit = audit.PartnerStatus == 5005 ? audit.TotalAmount : null;
            Debit = audit.PartnerStatus == 5000 ? audit.TotalAmount : null;
        }

        public long TransactionID { get; set; }
        public long LineNumber { get; set; }
        public decimal? Debit { get; set; }
        public decimal? FCDebit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? FCCredit { get; set; }
        public string PostDate { get; set; }
        public string Currency { get; set; }
    }
}
