using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SilverCarnival.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RunningController : ControllerBase
    {
        private readonly ILogger<RunningController> _logger;

        public RunningController(ILogger<RunningController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public bool Get()
        {
            _logger.Log(LogLevel.Information, "Endpoint Hit");
            return true;
        }
    }
}