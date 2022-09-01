using System.Collections.Generic;
using System.Linq;
using TelepathyLabs.ShowReels.Domain.Data;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Domain.Repository
{
    public class ShowReelRepository : IShowReelRepository
    {
        private readonly TelepathyLabsDbContext _telepathyLabsDbContext;

        public ShowReelRepository(TelepathyLabsDbContext telepathyLabsDbContext) 
        {
            _telepathyLabsDbContext = telepathyLabsDbContext;
        }

        public ShowReel Create(ShowReel showReel)
        {
            _telepathyLabsDbContext.ShowReels.Add(showReel);
            _telepathyLabsDbContext.SaveChanges();
            return showReel;
        }

        public IEnumerable<ShowReel> GetAll()
        {
            var showReels = _telepathyLabsDbContext.ShowReels.ToList();
            return showReels;
        }
    }
}
