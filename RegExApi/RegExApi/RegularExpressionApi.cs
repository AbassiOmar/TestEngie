using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServicesRegEx;
using RegExModels.Models.Input;
using Microsoft.Extensions.Caching.Memory;

namespace RegExApi
{
    public  class RegularExpressionApi
    {
        private readonly IRegExStrategy validateRegEX;
        private readonly IPersistData persistData;  
        private readonly IMemoryCache memoryCache;

        public RegularExpressionApi(IRegExStrategy validateRegEX,
            IMemoryCache memoryCache,
            IPersistData persistData)
        {
            this.validateRegEX = validateRegEX;
            this.memoryCache = memoryCache;
            this.persistData = persistData;
        }
        [FunctionName("RegularExpressionApi")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            InputRegExModel inputService = JsonConvert.DeserializeObject<InputRegExModel>(requestBody);
            var response = this.validateRegEX.Matching(inputService.RegEx, inputService.Text, inputService.Flags, inputService.MatchingType,inputService.TextSubstitution);
            if(response!=null)
            {
                this.persistData.SetData(response);
            }
            return new OkObjectResult(response);
        }
    }
}
