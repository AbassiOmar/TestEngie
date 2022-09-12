using Microsoft.Extensions.Caching.Memory;
using RegExModels.Enumerations;
using RegExModels.Models;
using RegExModels.Models.Output;
using ServicesRegEx;
using ServicesRegEx.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExApi.Services
{
    public class ValidateRegExWithSubstitution : BaseValidateRegEx,IRegularExpressionService
    {
        public ValidateRegExWithSubstitution()
        {
        }
        public MatchingType matchingType => MatchingType.WithsSubstitution;

        public ResponseMatching IsMatchRegExWithText(string regEx, string text, List<char> flags, MatchingType matchingType,string substitution)
        {
            RegexOptions regExOptions = GetRegExOptions(flags);
            ResponseMatching responseMatching = new ResponseMatching();
            var isMatch = Regex.IsMatch(text, regEx, regExOptions);

            MatchCollection matches = Regex.Matches(text, regEx, regExOptions);
            string replacedText=  Regex.Replace(text, regEx, substitution);
            responseMatching.IsMatch = isMatch;
            responseMatching.NombreMatching = matches.Count;
            responseMatching.TextAfterSubstitution = replacedText;
            responseMatching.MatchingInformations = GetResponseMatchingFromMatchCollection(matches);
            return responseMatching;
        }
    }
}
