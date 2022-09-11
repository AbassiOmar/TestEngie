using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesRegEx
{
    public interface IRegExStrategyFactory
    {
        IRegularExpressionService[] Create();
    }
}
