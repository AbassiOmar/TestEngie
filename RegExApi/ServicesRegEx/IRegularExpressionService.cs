using RegExModels.Enumerations;
using RegExModels.Models.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesRegEx
{
    public interface IRegularExpressionService
    {
        MatchingType matchingType { get; }
        ResponseMatching IsMatchRegExWithText(string regEx, string text, List<char> flags, MatchingType matchingType, string Substitution);

    }
}
