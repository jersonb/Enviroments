using Enviroments.Lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Enviroments.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class EnviromentController : ControllerBase
    {
        private readonly ILogger<EnviromentController> _logger;
private readonly EnderecoService _e;
        public EnviromentController(ILogger<EnviromentController> logger,EnderecoService endereco)
        {
            _logger = logger;
            _e = endereco;
        }

        [HttpGet("")]
        public IActionResult GetAction()
            => Ok(_e.Csv());
    }
}