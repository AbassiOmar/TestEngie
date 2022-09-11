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

namespace RegExApi
{
    public  class GetHistorySearchApi
    {
        private readonly IMemoryCache memoryCache;

        public GetHistorySearchApi( IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        [FunctionName("GetHistorySearchApi")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var keys = GetAllKeysList(this.memoryCache);
            List<ResponseMatching> responseMatching = new List<ResponseMatching>(0);
            foreach (var key in keys)
            {
                if(this.memoryCache.TryGetValue<ResponseMatching>(key, out ResponseMatching response))
                {
                    responseMatching.Add(response);
                }

            }

            return new OkObjectResult(responseMatching);
        }

        private static List<string> GetAllKeysList(IMemoryCache cache)
        {
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(cache) as ICollection;
            var items = new List<string>();
            if (collection != null)
                foreach (var item in collection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    items.Add(val.ToString());
                }
            return items;
        }
    }
}
