using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RegExApi.Services;
using RegExApi.Singleton;
using ServicesRegEx;
using System;
using System.Collections.Generic;
using System.Text;
[assembly: FunctionsStartup(typeof(RegExApi.Startup))]
namespace RegExApi
{
    public class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IRegularExpressionService, ValidateRegExWithSubstitution>();
            builder.Services.AddScoped<IRegularExpressionService, ValidateRegEXWithOptionsFlag>();
            builder.Services.AddScoped<IRegularExpressionService, ValidateRegEXBasic>();
            builder.Services.AddScoped<IRegularExpressionService, ValidateRegEXWithoutOptions>();
            builder.Services.AddScoped<IRegExStrategy, RegExStrategy>();
            builder.Services.AddSingleton<SingletonService>();
            builder.Services.AddScoped<IPersistData, PersistData>();
            builder.Services.AddMemoryCache();

        }
    }
}
