using System;
using System.Collections.Generic;
using System.Text;

namespace RegExModels.Models.Output
{
    public class ResponseMatching
    {
        public bool IsMatch { get; set; }
        public int NombreMatching { get; set; }
        public string TextAfterSubstitution { get; set; }
        public List<MatchingInformation> MatchingInformations { get; set; }
    }
}
