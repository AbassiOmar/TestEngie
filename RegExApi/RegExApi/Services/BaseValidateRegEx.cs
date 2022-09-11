using RegExModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExApi.Services
{
    public abstract class BaseValidateRegEx
    {
        public  List<MatchingInformation> GetResponseMatchingFromMatchCollection(MatchCollection matches)
        {
            List<MatchingInformation> matchsinfo = new List<MatchingInformation>(0);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                var matchInfo = new MatchingInformation();
                for (int i = 0; i <= groups.Count; i++)
                {
                    if (i == 0)
                    {

                        matchInfo = new MatchingInformation()
                        {
                            IdMatching = "Full Match",
                            TitleMtching = "Group " + groups[0].Name,
                            ValueMatching = groups[0].Value,
                            MatchingPositionLength = groups[0].Index + "-" + groups[0].Length
                        };
                        matchInfo.Groupes = new List<Groupe>(0);


                    }
                    else
                    {
                        var matchgroup = new Groupe()
                        {
                            IdGroup = "Group " + i.ToString(),
                            TitleGroup = "Group " + groups[i].Name,
                            ValueGroup = groups[i].Value,
                            MatchingPositionLength = groups[i].Index + "-" + groups[i].Length

                        };
                        matchInfo.Groupes.Add(matchgroup);
                    }

                }

                matchsinfo.Add(matchInfo);
            }
            return matchsinfo;
        }
        public RegexOptions GetRegExOptions(List<char> flags)
        {
            RegexOptions regExOptions = RegexOptions.None;

            if (flags.Contains('x'))
            {
                regExOptions |= RegexOptions.Multiline;
            }

            if (flags.Contains('i'))
            {
                regExOptions |= RegexOptions.IgnoreCase;
            }

            if (flags.Contains('s'))
            {
                regExOptions |= RegexOptions.Singleline;
            }

            if (flags.Contains('m'))
            {
                regExOptions |= RegexOptions.ExplicitCapture;
            }

            return regExOptions;
        }
    }
}
