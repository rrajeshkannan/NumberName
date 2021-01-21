using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumberName.Server.Identity.Services;

namespace NumberName.Server.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        private readonly ILogger<IdentityController> _logger;

        public IdentityController(
            IIdentityService identityService,
            ILogger<IdentityController> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        // GET: api/<IdentityController>
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_identityService.GetServerIdentity());
        }
    }
}