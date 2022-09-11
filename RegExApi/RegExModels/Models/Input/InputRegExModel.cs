using RegExModels.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegExModels.Models.Input
{
    public class InputRegExModel
    {
        public MatchingType MatchingType { get; set; }
        public string RegEx { get; set; }
        public string Text { get; set; }
        public List<char> Flags { get; set; }
        public string TextSubstitution { get; set; }
    }
}
