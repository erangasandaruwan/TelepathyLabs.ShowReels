namespace TelepathyLabs.ShowReels.Api.Dto
{
    public class TimeCodeRequestDto
    {
        public int? Id { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Frames { get; set; }
    }
}
