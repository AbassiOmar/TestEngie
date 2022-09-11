using System;
using System.Collections.Generic;
using System.Text;

namespace RegExModels.Models.Input
{
    public class InputRegExWithOption: InputRegEx
    {
        public List<char> Flags { get; set; }
    }
}
