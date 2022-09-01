namespace TelepathyLabs.ShowReels.Api.Dto
{
    public class VideoClipRequestDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public TimeCodeRequestDto StartTimeCode { get; set; }
        public TimeCodeRequestDto EndTimeCode { get; set; }
    }
}
