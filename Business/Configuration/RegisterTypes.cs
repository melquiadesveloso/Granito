using GranitoApi.Business.Integracao;
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
    public static class RegisterTypes
    { 
        public static void AddRegister(this IServiceCollection services)
        {
            services.AddScoped<ICalculo, Calculo>();
            services.AddScoped<IServiceTaxa, ServiceTaxa>(); 
          
         }
    }
}
