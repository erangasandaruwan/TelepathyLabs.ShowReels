using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TelepathyLabs.ShowReels.Api.Dto;
using TelepathyLabs.ShowReels.Api.Validator;
using TelepathyLabs.ShowReels.Domain.Entity;
using Xunit;

namespace TelepathyLabs.ShowReels.Tests.Api
{
    [ExcludeFromCodeCoverage]
    public class TimeCodeRequestDtoTests
    {
        public TimeCodeRequestDtoTests()
        {

        }

        [Fact]
        public void AllParametersShouldBePositive()
        {
            var validator = new TimeCodeRequestValidator();
            var timeCode1 = new TimeCodeRequestDto()
            {
                Hours = 1,
                Minutes = 1,
                Seconds = 1,
                Frames = -1,
            };
            var result1 = validator.Validate(timeCode1);
            Assert.Contains(result1.Errors, o => o.PropertyName == "Frames");

            var timeCode2 = new TimeCodeRequestDto()
            {
                Hours = 1,
                Minutes = 1,
                Seconds = -1,
                Frames = 1,
            };
            validator = new TimeCodeRequestValidator();
            var result2 = validator.Validate(timeCode2);
            Assert.Contains(result2.Errors, o => o.PropertyName == "Seconds");

            var timeCode3 = new TimeCodeRequestDto()
            {
                Hours = 1,
                Minutes = -1,
                Seconds = 1,
                Frames = 1,
            };
            validator = new TimeCodeRequestValidator();
            var result3 = validator.Validate(timeCode3);
            Assert.Contains(result3.Errors, o => o.PropertyName == "Minutes");

            var timeCode4 = new TimeCodeRequestDto()
            {
                Hours = -1,
                Minutes = 1,
                Seconds = 1,
                Frames = 1,
            };
            validator = new TimeCodeRequestValidator();
            var result4 = validator.Validate(timeCode4);
            Assert.Contains(result4.Errors, o => o.PropertyName == "Hours");
        }
    }
}
