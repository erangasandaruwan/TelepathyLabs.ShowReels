using System.Collections.Generic;
using TelepathyLabs.ShowReels.Core;
using TelepathyLabs.ShowReels.Core.Constants;
using TelepathyLabs.ShowReels.Domain.Entity;
using TelepathyLabs.ShowReels.Domain.Extension;
using TelepathyLabs.ShowReels.Domain.Repository;

namespace TelepathyLabs.ShowReels.Domain.Service
{
    public class ShowReelService : IShowReelService
    {
        private readonly IShowReelRepository _showReelRepository;
        public ShowReelService(IShowReelRepository showReelRepository)
        {
            _showReelRepository = showReelRepository;
        }

        public ShowReel Create(ShowReel showReel)
        {
            foreach (var videoClip in showReel.VideoClips)
            {
                videoClip.StartTimeCode.FramesPerSecond = FrameRate.values[videoClip.VideoStandard];
                videoClip.EndTimeCode.FramesPerSecond = FrameRate.values[videoClip.VideoStandard];
            }

            // Check video clips standards
            if (!showReel.AllVideoStandardsValid())
                throw new ShowReelException("All video clips should be in same video standard as the show reel.");

            // Check video clips' definitions
            if (!showReel.AllVideoDefinitionsValid())
                throw new ShowReelException("All video clips should be in same video definition as the show reel.");

            // Check video clips' start and end time codes are overlapping
            if (!showReel.VideoClips.TimeStampsOverlap())
                throw new ShowReelException("Video clips' start and end timecodes cannot overlap in all videos.");

            // Check all videos' frame rates of start and end time matches
            if (!showReel.VideoClips.IsStartEndFrameRateMatch())
                throw new ShowReelException("Frame rates for start time and end time should match for all videos.");

            // Check all videos' number of frames are less than frames per second
            if (!showReel.VideoClips.IsValidFrameRate())
                throw new ShowReelException("Frame rates for start time and end time should match for all videos.");


            return _showReelRepository.Create(showReel);
        }

        public IEnumerable<ShowReel> GetAll()
        {
            return _showReelRepository.GetAll();
        }
    }
}
