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
    public class MainClass
    {
        private readonly IAccountProvider _accountProvider;
        private readonly IAccountProcessor _accountProcessor;
        public MainClass(IAccountProcessor accountProcessor, IAccountProvider accountProvider)
        {
           _accountProcessor = accountProcessor;
           _accountProvider = accountProvider;
        }
        [FunctionName("DITestingFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            List<Account> list = _accountProvider.GetAccounts();
            int total = _accountProcessor.Process(list);

            var response = total.ToString();
            return new OkObjectResult(response);
        }
    }
}
