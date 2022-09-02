using System.Collections.Generic;
using TelepathyLabs.ShowReels.Api.Dto;
using TelepathyLabs.ShowReels.Api.Validator;
using Xunit;

namespace TelepathyLabs.ShowReels.Tests.Api
{
    public class ShowReelRequestDtoTests
    {
        [Fact]
        public void ShowReelShouldAtleastHaveOneVideoClip()
        {
            var validator = new ShowReelRequestValidator();

            var showReelRequest = new ShowReelRequestDto()
            {
                Name = "Sh1",
                Description = "Sh1 Description",
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                VideoClips = new List<VideoClipRequestDto>()
            };

            var result = validator.Validate(showReelRequest);
            Assert.Contains(result.Errors, o => o.PropertyName == "VideoClips");
        }
    }
}
