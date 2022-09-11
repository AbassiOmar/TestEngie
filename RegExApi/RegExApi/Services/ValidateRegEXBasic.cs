using RegExModels.Enumerations;
using RegExModels.Models.Output;
using ServicesRegEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExApi.Services
{
    public class ValidateRegEXBasic : IRegularExpressionService
    {
        public MatchingType matchingType => MatchingType.Basic;

        public ResponseMatching IsMatchRegExWithText(string regEx, string text, List<char> flags, MatchingType matchingType, string Substitution)
        {
            ResponseMatching responseMatching = new ResponseMatching();
            Regex rgx = new Regex(regEx);
            responseMatching.IsMatch = rgx.IsMatch(text);
            return responseMatching;
        }
    }
}
