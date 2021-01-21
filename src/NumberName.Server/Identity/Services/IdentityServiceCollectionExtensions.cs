using Microsoft.Extensions.DependencyInjection;

namespace NumberName.Server.Identity.Services
{
    public static class IdentityServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(
             this IServiceCollection services)
        {
            services.AddSingleton<IIdentityService, IdentityService>();

            return services;
        }
    }
}