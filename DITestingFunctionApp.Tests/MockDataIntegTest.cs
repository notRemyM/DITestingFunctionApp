using DITestingFunctionApp;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DITestingFunctionApp.Interfaces;
using Microsoft.Extensions.Logging;
using DITestingFunctionApp.Tests.Helpers;

namespace DITestingFunctionApp.Tests
{
    public class AccountProcessorTest
    {
        readonly DITestingFunction diTestingFunction;

        public AccountProcessorTest()
        {
            var testStartup = new IntegTestStartup();
            var host = new HostBuilder()
                .ConfigureWebJobs(testStartup.Configure)
                .Build();
            diTestingFunction = new DITestingFunction(host.Services.GetRequiredService<IAccountProcessor>());
        }

        [Fact]
        public void MockData()
        {
            // arrange
            var req = new DefaultHttpRequest(new DefaultHttpContext());

            // act
            var result = (OkObjectResult)diTestingFunction.Run(req).Result;

            // assert
            Assert.Equal(1365, result.Value);

        }
    }
}