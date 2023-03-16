using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DITestingFunctionApp.Interfaces;
using DITestingFunctionApp.Classes;
using System.Collections.Generic;

namespace DITestingFunctionApp
{
    public class DITestingFunction
    {
        private readonly IAccountProcessor _accountProcessor;
        public DITestingFunction(IAccountProcessor accountProcessor)
        {
           _accountProcessor = accountProcessor;
        }
        [FunctionName("DITestingFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            int total = _accountProcessor.Process();

            var response = total;
            return new OkObjectResult(response);
        }
    }
}
