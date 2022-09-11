using Microsoft.Extensions.Caching.Memory;
using RegExModels.Enumerations;
using RegExModels.Models.Output;
using ServicesRegEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExApi.Services
{
    public class RegExStrategy:IRegExStrategy
    {
		private readonly IEnumerable<IRegularExpressionService> _regExServices;
		private readonly IMemoryCache memoryCache;
		public RegExStrategy(IEnumerable<IRegularExpressionService> regExServices,
			IMemoryCache memoryCache)
		{
			_regExServices = regExServices;
			this.memoryCache = memoryCache;
		}

	   public ResponseMatching Matching(string regEx, string text, List<char> flags, MatchingType matchingType, string substitution)
        {
			var response = _regExServices.FirstOrDefault(x => x.matchingType == matchingType)?.IsMatchRegExWithText(regEx, text, flags, matchingType, substitution) ?? throw new ArgumentNullException(nameof(matchingType));
			if(response !=null )
            {

				_ = this.memoryCache?.Set("Matching - " + DateTime.UtcNow, response) ??
                    throw new ArgumentNullException(nameof(memoryCache));
			}
			return response;
		}
    }
}
