using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Domain.Repository
{
    public interface IShowReelRepository
    {
        ShowReel Create(ShowReel entity);

        IEnumerable<ShowReel> GetAll();
    }
}
