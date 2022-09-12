using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Moq;
using RegExApi.Services;
using RegExApiTest.constants;
using RegExModels.Enumerations;
using RegExModels.Models.Output;
using ServicesRegEx;
using System;
using System.Collections.Generic;
using Xunit;

namespace RegExApiTest
{
    public class ValidationRegExWithOpitionsTest
    {
        private readonly Mock<IRegularExpressionService> _regExValidationService;
        private readonly Mock<ValidateRegEXBasic> _regExValidationBasic;
        private readonly Mock<ValidateRegEXWithOptionsFlag> _regExValidationWithOptions;
        private readonly Mock<ValidateRegEXWithoutOptions> _regExValidationWithoutOptions;
        private readonly Mock<ValidateRegExWithSubstitution> _regExValidationWithouSubstitution;
        private readonly Mock<IMemoryCache> _memoryCache;

        public ValidationRegExWithOpitionsTest()
        {
            _regExValidationService = new Mock<IRegularExpressionService>();
            _regExValidationBasic = new Mock<ValidateRegEXBasic>(); ;
            _regExValidationWithOptions = new Mock<ValidateRegEXWithOptionsFlag>();
            _regExValidationWithoutOptions = new Mock<ValidateRegEXWithoutOptions>();
            _regExValidationWithouSubstitution = new Mock<ValidateRegExWithSubstitution>();
            _memoryCache = new Mock<IMemoryCache>();
        }
        [Theory]
        [InlineData(MatchingType.WithOptionFlags, SeedDataTest.RegExPhoneNumberOk, SeedDataTest.RegExInputTextOk, SeedDataTest.RegExInputReplaceOk)]
        [InlineData(MatchingType.WithsSubstitution, SeedDataTest.RegExPhoneNumberOk, SeedDataTest.RegExInputTextOk, SeedDataTest.RegExInputReplaceOk)]
        [InlineData(MatchingType.Basic, SeedDataTest.RegExPhoneNumberOk, SeedDataTest.RegExInputTextOk, SeedDataTest.RegExInputReplaceOk)]
        public void RegEx_Test_Ok(MatchingType matchingType,string regex,string text,string substition)
        {
            List<char> flags = new List<char>() { 'm' };
            this._regExValidationService.Setup(ser => ser.matchingType).Returns(matchingType);
            List<IRegularExpressionService> listService = new List<IRegularExpressionService>();
            listService.Add(_regExValidationBasic.Object);
            listService.Add(_regExValidationWithOptions.Object);
            listService.Add(_regExValidationWithoutOptions.Object);
            listService.Add(_regExValidationWithouSubstitution.Object);
           
            var cachEntry = Mock.Of<ICacheEntry>();
            Mock.Get(cachEntry).SetupGet(c => c.ExpirationTokens).Returns(new List<IChangeToken>());

            _memoryCache
                .Setup(m => m.CreateEntry(It.IsAny<object>()))
                .Returns(cachEntry);

            var strategy = new RegExStrategy(listService, _memoryCache.Object);
            var resultMatching = strategy.Matching(regex, text, flags, matchingType, substition);
           switch(matchingType)
            {
                case MatchingType.Basic:
                    Assert.True(resultMatching.IsMatch);
                    break;
                case MatchingType.WithMatchingInformation:
                    Assert.True(resultMatching.IsMatch);
                    Assert.Equal(resultMatching.NombreMatching,2);
                    break;
                case MatchingType.WithOptionFlags:
                    Assert.True(resultMatching.IsMatch);
                    Assert.Equal(resultMatching.NombreMatching, 6);
                    break;
                case MatchingType.WithsSubstitution:
                    Assert.True(resultMatching.IsMatch);
                    Assert.Equal(resultMatching.NombreMatching, 6);
                    break;
                default:
                    break;
            }
            
        }
    }
}
