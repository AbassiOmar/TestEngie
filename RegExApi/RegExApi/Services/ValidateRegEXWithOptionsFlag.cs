using RegExModels.Enumerations;
using RegExModels.Models;
using RegExModels.Models.Output;
using ServicesRegEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExApi.Services
{
    public class ValidateRegEXWithOptionsFlag : BaseValidateRegEx, IRegularExpressionService
    {
        public MatchingType matchingType =>MatchingType.WithOptionFlags;

        public ResponseMatching IsMatchRegExWithText(string regEx, string text, List<char> flags, MatchingType matchingType, string Substitution)
        {
            RegexOptions regExOptions = GetRegExOptions(flags);
            ResponseMatching responseMatching = new ResponseMatching();
            var isMatch = Regex.IsMatch(text, regEx, regExOptions);

            MatchCollection matches = Regex.Matches(text, regEx, regExOptions);

            responseMatching.IsMatch = isMatch;
            responseMatching.NombreMatching = matches.Count;
            responseMatching.MatchingInformations = GetResponseMatchingFromMatchCollection(matches);
            return responseMatching;
        }

    }
}
