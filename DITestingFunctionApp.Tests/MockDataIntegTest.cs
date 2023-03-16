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
    public class IntegrationTests
    {
        [Fact]
        public void IntegTestMockData()
        {
            // arrange
            var req = new DefaultHttpRequest(new DefaultHttpContext());
            var testStartup = new IntegTestStartup();
            var host = new HostBuilder()
                .ConfigureWebJobs(testStartup.Configure)
                .Build();
            var diTestingFunction = new DITestingFunction(host.Services.GetRequiredService<IAccountProcessor>());

            // act
            var result = (OkObjectResult)diTestingFunction.Run(req).Result;

            // assert
            Assert.Equal(1337, result.Value);

        }

        [Fact]
        public void IntegTestRealData()
        {
            // arrange
            var req = new DefaultHttpRequest(new DefaultHttpContext());
            var testStartup = new Startup();
            var host = new HostBuilder()
                .ConfigureWebJobs(testStartup.Configure)
                .Build();
            var diTestingFunction = new DITestingFunction(host.Services.GetRequiredService<IAccountProcessor>());

            // act
            var result = (OkObjectResult)diTestingFunction.Run(req).Result;

            // assert
            Assert.Equal(36, result.Value);

        }
    }
}