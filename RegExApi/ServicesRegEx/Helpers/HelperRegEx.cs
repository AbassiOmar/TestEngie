using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ServicesRegEx.Helpers
{
    public static class HelperRegEx
    {
        public static RegexOptions GetRegExOptions(List<char> flags)
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
