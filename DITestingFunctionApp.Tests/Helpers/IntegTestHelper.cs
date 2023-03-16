using DITestingFunctionApp.Classes;
using DITestingFunctionApp.Interfaces;
using DITestingFunctionApp.Providers;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITestingFunctionApp.Tests.Helpers
{
    public class IntegTestStartup : Startup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            base.Configure(builder);
            builder.Services.AddSingleton<IAccountProvider, MockAccountProvider>();
        }
    }

    public class MockAccountProvider : IAccountProvider
    {
        public List<Account> GetAccounts()
        {
            var accounts = new List<Account>();

            accounts.Add(new Account { id = 7, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 1330, name = "Remy", password = "Test" });

            return accounts;
        }
    }


}
