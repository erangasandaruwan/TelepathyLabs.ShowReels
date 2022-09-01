using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelepathyLabs.ShowReels.Domain.Service
{
    public class VideoDefinitionService : IVideoDefinitionService
    {
        public VideoDefinitionService()
        {

        }

        public List<KeyValuePair<int, string>> GetAll()
        {
            var values = Enum.GetValues(typeof(VideoDefinition))
                .Cast<VideoDefinition>()
                .Select(v => new KeyValuePair<int, string>((int)v, v.ToString()))
                .ToList();

            return values;
        }
    }
}
