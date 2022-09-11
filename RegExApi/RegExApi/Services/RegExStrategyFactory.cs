using ServicesRegEx;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegExApi.Services
{
    public class RegExStrategyFactory : IRegExStrategyFactory
    {
		private readonly ValidateRegEXBasic _regexBasic;
		private readonly ValidateRegEXWithoutOptions _regexWithoutOptions;
		private readonly ValidateRegEXWithOptionsFlag _regexWithOptions;

		public RegExStrategyFactory(
			ValidateRegEXBasic regexBasic,
			ValidateRegEXWithoutOptions regexWithoutOptions,
			ValidateRegEXWithOptionsFlag regexWithOptions
			)
		{
			_regexBasic = regexBasic;
			_regexWithoutOptions = regexWithoutOptions;
			_regexWithOptions = regexWithOptions;
		}

		public IRegularExpressionService[] Create() => new IRegularExpressionService[] { _regexBasic, _regexWithOptions,_regexWithoutOptions };
	
    }
}
