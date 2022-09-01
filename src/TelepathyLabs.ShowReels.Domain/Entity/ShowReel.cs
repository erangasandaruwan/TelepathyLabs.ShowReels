using System;
using System.Collections.Generic;
using TelepathyLabs.ShowReels.Core.Model.EntityBase;

namespace TelepathyLabs.ShowReels.Domain.Entity
{
    public class ShowReel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VideoStandard VideoStandard { get; set; }
        public VideoDefinition VideoDefinition { get; set; }
        public List<VideoClip> VideoClips { get; set; }
    }
}
