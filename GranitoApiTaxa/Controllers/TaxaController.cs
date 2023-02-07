using Microsoft.AspNetCore.Mvc;

namespace GranitoApiTaxa.Controllers
{
    [ApiController]
    [Route("granito/api/[controller]")]
    public class TaxaController : ControllerBase
    {
        
        private readonly ILogger<TaxaController> _logger;

        public TaxaController(ILogger<TaxaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Taxa")]
        public decimal Get()
        {
            return Taxa._Taxa;
        }
    }
}