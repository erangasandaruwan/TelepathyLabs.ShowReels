using TelepathyLabs.ShowReels.Core.Model.EntityBase;

namespace TelepathyLabs.ShowReels.Domain.Entity
{
    public class VideoClip : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public TimeCode StartTimeCode { get; set; }
        public TimeCode EndTimeCode { get; set; }
    }
}
