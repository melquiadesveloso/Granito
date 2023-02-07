using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitoApi.Business.Configuration
{
    public static class RegisterLogger
    {
        public static void AddRegisterLogger(this IServiceCollection services)
        {
            var logger = ConfigurationLogger();

            logger.Write(Serilog.Events.LogEventLevel.Information, "Iniciando aplicação");

       

        }

        private static Logger ConfigurationLogger()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile("@log.txt", retainedFileCountLimit: 8, fileSizeLimitBytes: 409600)
                .CreateLogger();

            return logger;
        }
    }
}
