using System.Collections.Generic;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Domain.Extension
{
    public static class VideoClipExtension
    {
        public static bool IsStartEndFrameRateMatch(this List<VideoClip> videoClips)
        {
            foreach (var videoClip in videoClips)
            {
                if (videoClip.StartTimeCode.FramesPerSecond != videoClip.EndTimeCode.FramesPerSecond)
                    return false;
            }


            return true;
        }

        public static bool TimeStampsOverlap(this List<VideoClip> videoClips)
        {
            for (int x = 1; x < videoClips.Count; x++)
            {
                if (videoClips[x - 1].EndTimeCode.TotalFrames == null || videoClips[x - 1].EndTimeCode.TotalFrames == 0 ||
                    videoClips[x - 1].StartTimeCode.TotalFrames == null || videoClips[x - 1].StartTimeCode.TotalFrames == 0 ||
                    (videoClips[(x - 1)].EndTimeCode.TotalFrames >= videoClips[x].StartTimeCode.TotalFrames))
                {
                    return false;
                }
            }

            return true;
        }


        public static bool IsValidFrameRate(this List<VideoClip> videoClips)
        {
            foreach (var videoClip in videoClips)
            {
                if (videoClip.StartTimeCode.Frames >= videoClip.StartTimeCode.FramesPerSecond)
                {
                    return false;
                }

                if (videoClip.EndTimeCode.Frames >= videoClip.EndTimeCode.FramesPerSecond)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
