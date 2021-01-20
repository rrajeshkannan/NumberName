using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NumberName.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly ILogger<IdentityController> _logger;

        public IdentityController(
            IConfiguration configuration, 
            ILogger<IdentityController> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        // GET: api/<IdentityController>
        [HttpGet]
        public ContentResult Get()
        {
            var jsonKey = $"\"{Configuration["ApiServer:Key"]}\"";
            var jsonValue = $"\"{Configuration["ApiServer:Value"]}\"";
            var jsonResponse = $"{{{jsonKey}:{jsonValue}}}";

            return Content(jsonResponse, "application/json");
        }
    }
}