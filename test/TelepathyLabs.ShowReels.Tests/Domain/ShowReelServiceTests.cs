using Moq;
using System.Collections.Generic;
using TelepathyLabs.ShowReels.Core;
using TelepathyLabs.ShowReels.Domain.Entity;
using TelepathyLabs.ShowReels.Domain.Repository;
using TelepathyLabs.ShowReels.Domain.Service;
using Xunit;

namespace TelepathyLabs.ShowReels.Tests.Domain
{
    public class ShowReelServiceTests
    {
        private Mock<IShowReelRepository> _mockShowReelRepository;
        private ShowReelService _ShowReelService;

        public ShowReelServiceTests()
        {
            _mockShowReelRepository = new Mock<IShowReelRepository>();

            _mockShowReelRepository
                .Setup(mr => mr.Create(It.IsAny<ShowReel>()))
                .Returns(new ShowReel());
            _mockShowReelRepository
                .Setup(mr => mr.GetAll())
                .Returns(new List<ShowReel>());

            _ShowReelService = new ShowReelService(_mockShowReelRepository.Object);
        }

        /// <summary>
        /// // Check video clips standards
        /// </summary>
        [Fact]
        public void VideoClipShouldHaveTheSameVideoStandard()
        {
            var showReel = new ShowReel()
            {
                Name = "Sh1",
                Description = "Sh1 Description",
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                VideoClips = new List<VideoClip>()
                {
                    new VideoClip()
                    {
                        Name = "Cl1",
                        Description = "Cl1 description",
                        VideoDefinition = VideoDefinition.HD,
                        VideoStandard = VideoStandard.PAL,
                        StartTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                        EndTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                    }
                }
            };

            Assert.Throws<ShowReelException>(() => _ShowReelService.Create(showReel));
        }

        /// <summary>
        /// Check video clips' definitions
        /// </summary>
        [Fact]
        public void AllClipsInShowReelShouldHaveSameVideoDefinition()
        {
            var showReel = new ShowReel()
            {
                Name = "Sh1",
                Description = "Sh1 Description",
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                VideoClips = new List<VideoClip>()
                {
                    new VideoClip()
                    {
                        Name = "Cl1",
                        Description = "Cl1 description",
                        VideoDefinition = VideoDefinition.SD,
                        VideoStandard = VideoStandard.NTSC,
                        StartTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                        EndTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                    }
                }
            };

            Assert.Throws<ShowReelException>(() => _ShowReelService.Create(showReel));
        }

        /// <summary>
        /// Check video clips' start and end time codes are overlapping
        /// </summary>
        [Fact]
        public void ClipsShouldNotOverlap()
        {
            var showReel = new ShowReel()
            {
                Name = "Sh1",
                Description = "Sh1 Description",
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                VideoClips = new List<VideoClip>()
                {
                    new VideoClip()
                    {
                        Name = "Cl1",
                        Description = "Cl1 description",
                        VideoDefinition = VideoDefinition.HD,
                        VideoStandard = VideoStandard.NTSC,
                        StartTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                        EndTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                    },
                    new VideoClip()
                    {
                        Name = "Cl2",
                        Description = "Cl2 description",
                        VideoDefinition = VideoDefinition.HD,
                        VideoStandard = VideoStandard.NTSC,
                        StartTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                        EndTimeCode = new TimeCode(){  Hours = 1, Minutes = 1, Seconds = 1, Frames = 1, FramesPerSecond = 2},
                    }
                }
            };

            Assert.Throws<ShowReelException>(() => _ShowReelService.Create(showReel));
        }

        /// Check all videos' frame rates of start and end time matches
        /// 

        /// Check all videos' number of frames are less than frames per second
        /// 
    }
}
