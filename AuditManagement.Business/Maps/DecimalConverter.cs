using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace AuditManagement.Business.Maps
{
    public class NullDecimalConverter : DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData mapData)
        {
            if (text == "NULL")
            {
                return null;
            }
            return base.ConvertFromString(text, row, mapData);
        }
    }
}
