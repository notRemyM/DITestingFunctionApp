using DITestingFunctionApp.Implementations;
using DITestingFunctionApp.Interfaces;
using DITestingFunctionApp.Providers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(DITestingFunctionApp.Startup))]

namespace DITestingFunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();
            builder.Services.AddSingleton<IAccountProcessor, AccountProcessor>();
            builder.Services.AddSingleton<IAccountProvider, AccountProvider>();
        }
    }
}