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
		public RegExStrategy(IEnumerable<IRegularExpressionService> regExServices)
		{
			_regExServices = regExServices;
		}

	   public ResponseMatching Matching(string regEx, string text, List<char> flags, MatchingType matchingType, string substitution)
        {
			return _regExServices.FirstOrDefault(x => x.matchingType == matchingType)?.IsMatchRegExWithText(regEx, text, flags, matchingType, substitution) ?? throw new ArgumentNullException(nameof(matchingType));
		}
    }
}
