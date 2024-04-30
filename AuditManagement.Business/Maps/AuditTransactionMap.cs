using AuditManagement.Models;
using CsvHelper.Configuration;

namespace AuditManagement.Business.Maps
{
    public class AuditTransactionMap : ClassMap<AuditTransaction>
    {
        public AuditTransactionMap()
        {
            Map(m => m.AuditTransactionId);
            Map(m => m.AuditId);
            Map(m => m.Refnumber);
            Map(m => m.PartnerReference);
            Map(m => m.ConfirmedDate);
            Map(m => m.TransactionDate);
            Map(m => m.Id);
            Map(m => m.OfferId);
            Map(m => m.Country);
            Map(m => m.ToCurr);
            Map(m => m.Bank);
            Map(m => m.PartnerMTAI);
            Map(m => m.Sarb);
            Map(m => m.PrincipleSpreadDCMZAR).TypeConverter<NullDecimalConverter>();
            Map(m => m.TotalAmount).TypeConverter<NullDecimalConverter>();
            Map(m => m.XEDCM).TypeConverter<NullDecimalConverter>();
            Map(m => m.HPAfterMarkUp).TypeConverter<NullDecimalConverter>();
            Map(m => m.ZARTotalSpread).TypeConverter<NullDecimalConverter>();
            Map(m => m.HPZARSpread).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCMZARSpread).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCMUSDSpread).TypeConverter<NullDecimalConverter>();
            Map(m => m.TotalTransFee).TypeConverter<NullDecimalConverter>();
            Map(m => m.HPTransFeeZAR).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCMTransFeeZAR).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCMTransFeeUSD).TypeConverter<NullDecimalConverter>();
            Map(m => m.OfferAmount).TypeConverter<NullDecimalConverter>();
            Map(m => m.Base).TypeConverter<NullDecimalConverter>();
            Map(m => m.MarkUp).TypeConverter<NullDecimalConverter>();
            Map(m => m.Randdiff).TypeConverter<NullDecimalConverter>();
            Map(m => m.Perc).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCM).TypeConverter<NullDecimalConverter>();
            Map(m => m.USDMarkUp).TypeConverter<NullDecimalConverter>();
            Map(m => m.USDPerc).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCMZAR).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCMZARMarkUp).TypeConverter<NullDecimalConverter>();
            Map(m => m.DCMZARPerc).TypeConverter<NullDecimalConverter>();
            Map(m => m.DaytonaUSDBase).TypeConverter<NullDecimalConverter>();
            Map(m => m.DaytonaUSDMarkUp).TypeConverter<NullDecimalConverter>();
            Map(m => m.DaytonaPerc).TypeConverter<NullDecimalConverter>();
            Map(m => m.DaytonaZARBase).TypeConverter<NullDecimalConverter>();
            Map(m => m.DaytonaZARMarkUp).TypeConverter<NullDecimalConverter>();
            Map(m => m.DaytonaZARPerc).TypeConverter<NullDecimalConverter>();
            Map(m => m.InternalServiceFeeZAR).TypeConverter<NullDecimalConverter>();
            Map(m => m.InternalServiceFeeUSD).TypeConverter<NullDecimalConverter>();
            Map(m => m.MatchStatus);
            Map(m => m.PartnerStatus);
            Map(m => m.DTBaseLive).TypeConverter<NullDecimalConverter>();
        }
    }
}
