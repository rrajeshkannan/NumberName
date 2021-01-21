using NumberName.Server.Identity.Model;

namespace NumberName.Server.Identity.Services
{
    public interface IIdentityService
    {
        ServerIdentity GetServerIdentity();
    }
}