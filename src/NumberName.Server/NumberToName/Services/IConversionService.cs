using NumberName.Server.NumberToName.Model;

namespace NumberName.Server.NumberToName.Services
{
    public interface IConversionService
    {
        public NumberNameOutput ConvertFrom(NumberNameInput number);
    }
}