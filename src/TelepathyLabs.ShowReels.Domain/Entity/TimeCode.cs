using System.ComponentModel.DataAnnotations.Schema;
using TelepathyLabs.ShowReels.Core.Model.EntityBase;

namespace TelepathyLabs.ShowReels.Domain.Entity
{
    public class TimeCode : BaseModel
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Frames { get; set; }
        public int FramesPerSecond { get; set; }
        [NotMapped]
        public int TotalFrames
        {
            get
            {
                return Frames + (Seconds + Minutes * 60 + Hours * 3600) * FramesPerSecond;
            }
        }
    }
}
