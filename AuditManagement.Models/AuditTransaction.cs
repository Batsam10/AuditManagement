namespace AuditManagement.Models
{
    public class AuditTransaction
    {
        public long AuditTransactionId { get; set; }
        public long AuditId { get; set; }
        public string Refnumber { get; set; }
        public string PartnerReference { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public long Id { get; set; }
        public long OfferId { get; set; }
        public string Country { get; set; }
        public string ToCurr { get; set; }
        public string Bank { get; set; }
        public string PartnerMTAI { get; set; }
        public string? Sarb { get; set; }
        public decimal? PrincipleSpreadDCMZAR { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? XEDCM { get; set; }
        public decimal? HPAfterMarkUp { get; set; }
        public decimal? ZARTotalSpread { get; set; }
        public decimal? HPZARSpread { get; set; }
        public decimal? DCMZARSpread { get; set; }
        public decimal? DCMUSDSpread { get; set; }
        public decimal? TotalTransFee { get; set; }
        public decimal? HPTransFeeZAR { get; set; }
        public decimal? DCMTransFeeZAR { get; set; }
        public decimal? DCMTransFeeUSD { get; set; }
        public decimal? OfferAmount { get; set; }
        public decimal? Base { get; set; }
        public decimal? MarkUp { get; set; }
        public decimal? Randdiff { get; set; }
        public decimal? Perc { get; set; }
        public decimal? DCM { get; set; }
        public decimal? USDMarkUp { get; set; }
        public decimal? USDPerc { get; set; }
        public decimal? DCMZAR { get; set; }
        public decimal? DCMZARMarkUp { get; set; }
        public decimal? DCMZARPerc { get; set; }
        public decimal?  DaytonaUSDBase { get; set; }
        public decimal? DaytonaUSDMarkUp { get; set; }
        public decimal? DaytonaPerc { get; set; }
        public decimal? DaytonaZARBase { get; set; }
        public decimal? DaytonaZARMarkUp { get; set; }
        public decimal? DaytonaZARPerc { get; set; }
        public decimal? InternalServiceFeeZAR { get; set; }
        public decimal? InternalServiceFeeUSD { get; set; }
        public int MatchStatus { get; set; }
        public int PartnerStatus { get; set; }
        public decimal? DTBaseLive { get; set; }
    }
}
