using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GranitoApi.Business.Integracao
{
    public class ServiceTaxa : IServiceTaxa
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ServiceTaxa> _logger;

      
        public ServiceTaxa(IConfiguration configuration, ILogger<ServiceTaxa> logger)
        {
           
            _configuration = configuration; 
            _logger = logger;
            _httpClient = Service();

        }

        public decimal GetTaxa()
        {
            var taxa = 0M;
 
            _logger.LogInformation("Buscando o valor da taxa");

            try
            {
                var response =  _httpClient.GetAsync("api/Taxa").GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Erro: Não foi possível encontrar o valor da taxa! {response.Content} ");
                    return taxa;
                }
                 
                  
                var res = response.Content.ReadAsStringAsync();
                taxa = Convert.ToDecimal(res.Result, CultureInfo.InvariantCulture);
                  
                return taxa;

            }
            catch (Exception ex)
            {

               _logger.LogError(ex, "Erro ao buscar valor da taxa.");
                return 0;
            }

        }

        public HttpClient Service()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration.GetSection("GranitoApiTaxa").GetValue<string>("EndPointTaxa"));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }
    }
}
