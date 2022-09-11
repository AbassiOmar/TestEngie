using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RegExApi.Singleton;
using System.Collections.Generic;

namespace RegExApi
{
    public  class TestSingleton
    {
        [FunctionName("TestSingleton")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            Parallel.Invoke(() => Test01(), () => Test02());
            //Test01();
            //Test02();
            return new OkObjectResult(SingletonService.Instance.messages);
        }

        private SingletonService Test01()
        {
            SingletonService Test01 = SingletonService.Instance;
            Test01.SertMessage("appel singleton pour Test01");
            return Test01;
        }

        private SingletonService Test02()
        {
            SingletonService Test02 = SingletonService.Instance;
            Test02.SertMessage("appel singleton pour Test02");
            return Test02;
        }
    }
}
