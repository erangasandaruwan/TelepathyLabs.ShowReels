using System;
using System.Collections.Generic;
using System.Text;

namespace TelepathyLabs.ShowReels.Domain.Service
{
    public interface IVideoStandardService
    {
        List<KeyValuePair<int, string>> GetAll();
    }
}
