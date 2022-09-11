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
    public class ValidateRegEXWithoutOptions : BaseValidateRegEx, IRegularExpressionService
    {
        public MatchingType matchingType => MatchingType.WithMatchingInformation;

        public ResponseMatching IsMatchRegExWithText(string regEx, string text, List<char> flags, MatchingType matchingType, string Substitution)
        {
            ResponseMatching responseMatching = new ResponseMatching();

            Regex rgx = new Regex(regEx);
            var isMatch = rgx.IsMatch(text);
            MatchCollection matches = rgx.Matches(text);
            responseMatching.IsMatch = isMatch;
            responseMatching.NombreMatching = matches.Count;
            responseMatching.MatchingInformations = GetResponseMatchingFromMatchCollection(matches);
            return responseMatching;
        }
    }

}
