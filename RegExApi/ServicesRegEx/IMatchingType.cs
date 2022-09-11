using RegExModels.Enumerations;
using RegExModels.Models.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesRegEx
{
    public interface IMatchingType
    {
        MatchingType matchingType { get; }

        ResponseMatching MatchingText(string regEx, string text, List<char> flags, MatchingType matchingType);
    }
}
