using System.Collections.Generic;

namespace TelepathyLabs.ShowReels.Api.Dto.Response
{
    public class ShowReelResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public List<VideoClipRequestDto> VideoClips { get; set; }
    }
}
