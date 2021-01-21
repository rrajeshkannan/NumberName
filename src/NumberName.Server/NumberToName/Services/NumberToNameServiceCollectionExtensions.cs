using Microsoft.Extensions.DependencyInjection;

namespace NumberName.Server.NumberToName.Services
{
    public static class NumberToNameServiceCollectionExtensions
    {
        public static IServiceCollection AddNumberToNameConversionServices(
             this IServiceCollection services)
        {
            services.AddSingleton<IConversionService, ConversionService>();

            return services;
        }
    }
}