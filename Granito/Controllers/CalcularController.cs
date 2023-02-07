using GranitoApi.Business;
using GranitoApi.Business.Entities;
using Microsoft.AspNetCore.Mvc;
namespace GranitoApi.Controllers
{
    [ApiController]
    [Route("granito/api/")]
    public class CalcularController : ControllerBase
    {
        private readonly ILogger<CalcularController> _logger;
        private readonly ICalculo _calculo; 

        public CalcularController(ILogger<CalcularController> logger, ICalculo calculo)
        {
            _logger = logger;
            _calculo = calculo;
        }

        [HttpGet("CalcularJuros")]
        public ActionResult<ResponseMessage> CalcularJuros(decimal valor, int meses)
        {

            try
            {
                return _calculo.Operacao(valor, meses);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("showmethecode")]
        public ActionResult<string> Showmethecode()
        {
            return "https://github.com/melquiadesveloso/Granito.git";
        } 
    }
}