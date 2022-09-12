using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RegExApiTest.constants
{
    public static class SeedDataTest
    {
        public const string RegExPhoneNumberOk = "(\\+33|0)?(\\d)?(\\d\\d)?(\\d\\d)?(\\d\\d)?(\\d\\d)";
        public const string RegExInputTextOk = "0768443109  abassi omar phone number 07 68 55 99 88";
        public const string RegExInputReplaceOk = "*****";

    }
}