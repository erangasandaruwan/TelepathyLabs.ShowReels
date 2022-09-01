using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelepathyLabs.ShowReels.Core.Constants
{
    public static class FrameRate
    {
        public static Dictionary<VideoStandard, int> values = new Dictionary<VideoStandard, int>()
        {
            { VideoStandard.NTSC, 30 },
            { VideoStandard.PAL, 25 }
        };
    }
}
