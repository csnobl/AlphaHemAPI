using AlphaHemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public class ListingRepository : GenericRepository<Listing>, IListingRepository
    {
        private readonly AlphaHemAPIDbContext _ctx;

        public ListingRepository(AlphaHemAPIDbContext ctx) :base(ctx)
        {
            this._ctx = ctx;
        }

        // Author : Smilla
        public async Task<List<Listing>> GetAllWithIncludesAsync()
        {
            return await _ctx.Listings
                             .Include(l => l.Municipality)
                             .Include(l => l.Realtor)
                             .ToListAsync();
        }
    }
}
