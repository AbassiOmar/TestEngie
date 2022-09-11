using System;
using System.Collections.Generic;
using System.Text;

namespace RegExModels.Models
{
    public class MatchingInformation
    {
        public string IdMatching { get; set; }
        public string TitleMtching { get; set; }
        public string ValueMatching { get; set; }
        public string MatchingPositionLength { get; set; }
        public List<Groupe> Groupes { get; set; }

    }
    public class Groupe
    {
        public string IdGroup { get; set; }
        public string TitleGroup { get; set; }
        public string ValueGroup { get; set; }
        public string MatchingPositionLength { get; set; }

    }
}
