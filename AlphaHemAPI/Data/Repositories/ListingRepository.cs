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
           _ctx = ctx;
        }

        // Author : Smilla
        public async Task<List<Listing>> GetAllWithIncludesAsync()
        {
            return await _ctx.Listings
                             .Include(l => l.Municipality)
                             .Include(l => l.Realtor)
                             .ToListAsync();
        }

        // Author : Smilla
        // Co-author: Conny
        public async Task<Listing?> GetByIdWithIncludesAsync(int id)
        {
            return await _ctx.Listings
                        .Include(l => l.Municipality)
                        .Include(l => l.Realtor)
                        .ThenInclude(r => r.Agency)
                        .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
