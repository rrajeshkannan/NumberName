using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumberName.Server.NumberToName.Model;
using NumberName.Server.NumberToName.Services;

namespace NumberName.Server.NumberToName
{
    [Route("[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        private readonly ILogger<ConvertController> _logger;

        public ConvertController(
            IConversionService conversionService,
            ILogger<ConvertController> logger)
        {
            _conversionService = conversionService;
            _logger = logger;
        }

        // POST api/<ConvertController>
        [HttpPost]
        public JsonResult Post([FromBody] NumberNameInput input)
        {
            return new JsonResult(_conversionService.ConvertFrom(input));
        }
    }
}