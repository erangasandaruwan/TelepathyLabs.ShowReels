using System.Collections.Generic;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Domain.Service
{
    public interface IShowReelService
    {
        public ShowReel Create(ShowReel showReel);
        public IEnumerable<ShowReel> GetAll();
    }
}
