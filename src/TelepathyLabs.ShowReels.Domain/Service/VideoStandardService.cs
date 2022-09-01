using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelepathyLabs.ShowReels.Domain.Service
{
    public class VideoStandardService : IVideoStandardService
    {
        public List<KeyValuePair<int, string>> GetAll()
        {
            var values = Enum.GetValues(typeof(VideoStandard))
                .Cast<VideoStandard>()
                .Select(v => new KeyValuePair<int, string>((int)v, v.ToString()))
                .ToList();

            return values;
        }
    }
}
