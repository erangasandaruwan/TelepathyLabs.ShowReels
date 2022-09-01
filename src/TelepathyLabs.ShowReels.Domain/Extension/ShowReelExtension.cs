using System;
using System.Collections.Generic;
using System.Text;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Domain.Extension
{
    public static class ShowReelExtension
    {
        public static bool AllVideoStandardsValid(this ShowReel showReel)
        {
            foreach (var videoClip in showReel.VideoClips)
            {
                if (videoClip.VideoStandard != showReel.VideoStandard)
                    return false;
            }

            return true;
        }

        public static bool AllVideoDefinitionsValid(this ShowReel showReel)
        {
            foreach (var videoClip in showReel.VideoClips)
            {
                if (videoClip.VideoDefinition != showReel.VideoDefinition)
                    return false;
            }

            return true;
        }
    }
}
