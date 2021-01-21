using Microsoft.Extensions.Configuration;
using NumberName.Server.Identity.Model;

namespace NumberName.Server.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        IConfiguration _configuration;

        public IdentityService(IConfiguration configuration)
            => _configuration = configuration;

        public ServerIdentity GetServerIdentity()
        {
            return new ServerIdentity { ServerName = _configuration["ApiServerName"] };
        }
    }
}