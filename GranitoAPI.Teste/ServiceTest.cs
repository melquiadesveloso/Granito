using GranitoApi.Business;
using GranitoApi.Business.Integracao;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using Xunit;

namespace GranitoAPI.Teste
{
    public class ServiceTest
    {
        Mock<ICalculo> _serviceCalculoMock;

        Mock<IServiceTaxa> _serviceTaxaMock;
        Mock<ILogger<Calculo>> _loggerCalculoMock;
        Mock<IConfiguration> _configurationMock;
        Mock<ILogger<ServiceTaxa>> _loggeServiceTaxaoMock;

        Calculo _calculo;
        ServiceTaxa _taxaService;

        public IConfiguration _Configuration;
         
        public ServiceTest()
        {
        
             
            _serviceCalculoMock = new Mock<ICalculo>();
            _serviceTaxaMock = new Mock<IServiceTaxa>();
            _loggerCalculoMock = new Mock<ILogger<Calculo>>();
            _loggeServiceTaxaoMock = new Mock<ILogger<ServiceTaxa>>();

             _configurationMock = new Mock<IConfiguration>();

             var appSettingsStub = new Dictionary<string, string> {
                {"GranitoApiTaxa:EndPointTaxa", "http://localhost:5028/granito/"} 
            };

            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(appSettingsStub)
            .Build();

            _Configuration = configuration; 
            _calculo = new Calculo(_serviceTaxaMock.Object, _loggerCalculoMock.Object);
            _taxaService = new ServiceTaxa(_Configuration, _loggeServiceTaxaoMock.Object);
        }

        [Fact]
        public void CheckTaxa()
        {
            decimal valorInicial = 100;
            int meses = 5;

            var res = _calculo.Operacao(valorInicial, meses);

            Assert.False(res.Result == "0");
        }
     }
}