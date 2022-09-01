using System;
using System.Collections.Generic;
using System.Text;

namespace TelepathyLabs.ShowReels.Domain.Service
{
    public interface IVideoDefinitionService
    {
        List<KeyValuePair<int, string>> GetAll();
    }
}
