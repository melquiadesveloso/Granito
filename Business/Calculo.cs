using GranitoApi.Business.Entities;
using GranitoApi.Business.Integracao;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Globalization;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace GranitoApi.Business
{
   
    public class Calculo : ICalculo
    {
        private readonly IServiceTaxa _serviceTaxa;
        private readonly ILogger<Calculo> _logger;

        public Calculo(IServiceTaxa serviceTaxa, ILogger<Calculo> logger)
        {
            _serviceTaxa = serviceTaxa;
            _logger = logger;
        }

        public ResponseMessage Operacao(decimal valor, int meses)
        {
            try
            {
                //Send API Taxa Taxa
                var taxa = _serviceTaxa.GetTaxa();
                if (taxa == 0)
                    throw new Exception("Erro: Não foi possível encontrar o valor da taxa!");
                    //Calcule value
                    var value = (valor * (1 + taxa));

                //Cacule exponent
                var r = (decimal)Math.Pow((double)value, meses);

                //Caclue value more one thousand
                var aux = GetDigit(r);

                //truncate value
                string trunc = ((trunc = aux.ToString("f16")).Substring(0, trunc.Length - 14));

                //Format value
                var restult = string.Format("{0:0.00}", trunc);

                return new ResponseMessage
                {
                    Message = $"Operação realizada com sucesso!",
                    Result = restult
                };
            }
            catch (Exception ex)
            {

                return new ResponseMessage
                {
                    Message = $"{ex.Message}",
                    Result = "0"
                };
            }

        } 

        static decimal GetDigit(decimal Value)
        {
 
            decimal firstdigit = 0;
             if (Value > 1000000000)
                firstdigit = Value / 100000000;
            else
                firstdigit = Value;

            return firstdigit;
         }
    }
}