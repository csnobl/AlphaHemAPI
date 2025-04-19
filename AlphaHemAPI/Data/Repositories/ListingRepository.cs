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
        // Co-author: Christoffer
        public async Task<List<Listing>> GetAllWithIncludesAsync(string? municipality = null)
        {
             var query = _ctx.Listings
                             .Include(l => l.Municipality)
                             .Include(l => l.Realtor)
                             .AsQueryable();

            if (!string.IsNullOrEmpty(municipality))
            { 
                query = query.Where(l => l.Municipality.Name.ToLower() == municipality.ToLower());
            }

            return await query.ToListAsync();
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
