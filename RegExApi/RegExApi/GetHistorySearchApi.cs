using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using RegExModels.Models.Output;
using ServicesRegEx;

namespace RegExApi
{
    public  class GetHistorySearchApi
    {
        private readonly IMemoryCache memoryCache;
        private readonly IPersistData persistData;
        public GetHistorySearchApi( IMemoryCache memoryCache,
            IPersistData persistData)
        {
            this.memoryCache = memoryCache;
            this.persistData = persistData;
        }
        [FunctionName("GetHistorySearchApi")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<ResponseMatching> responseMatching = this.persistData.GetData();
            return new OkObjectResult(responseMatching);
        }

       
    }
}
