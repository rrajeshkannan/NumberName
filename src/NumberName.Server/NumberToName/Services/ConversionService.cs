using NumberName.Server.NumberToName.Model;

namespace NumberName.Server.NumberToName.Services
{
    public class ConversionService : IConversionService
    {
        public NumberNameOutput ConvertFrom(NumberNameInput number)
        {
            var value = number.Value;

            var result = new NumberNameOutput { Value = value, ValueInWords = value.ConvertToWords() };

            return result;
        }
    }
}