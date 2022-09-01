using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Domain.Service;

namespace TelepathyLabs.ShowReels.Api.Handler.VideoDefinitions
{
    public interface IVideoDefinitionGetHandler
    {
        List<KeyValuePair<int, string>> Handle();
    }

    public class VideoDefinitionGetHandler : IVideoDefinitionGetHandler
    {
        private readonly IVideoDefinitionService _videoDefinitionService;

        public VideoDefinitionGetHandler(IVideoDefinitionService videoDefinitionService)
        {
            _videoDefinitionService = videoDefinitionService;
        }

        public List<KeyValuePair<int, string>> Handle()
        {
            return _videoDefinitionService.GetAll();
        }
    }
}
