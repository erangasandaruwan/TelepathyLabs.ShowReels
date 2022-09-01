using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Domain.Service;

namespace TelepathyLabs.ShowReels.Api.Handler.VideoStandards
{
    public interface IVideoStandardGetHandler
    {
        List<KeyValuePair<int, string>> Handle();
    }

    public class VideoStandardGetHandler : IVideoStandardGetHandler
    {
        private readonly IVideoStandardService _videoDefinitionService;

        public VideoStandardGetHandler(IVideoStandardService videoDefinitionService)
        {
            _videoDefinitionService = videoDefinitionService;
        }

        public List<KeyValuePair<int, string>> Handle()
        {
            return _videoDefinitionService.GetAll();
        }
    }
}
