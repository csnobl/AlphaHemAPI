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
        public async Task<(List<Listing> Listings, int TotalCount)> GetPagedListingsWithIncludesAsync(
            int pageIndex,
            int pageSize,
            string? municipality = null,
            string? category = null,
            string? sortBy = null)
        {
             var query = _ctx.Listings
                .Include(l => l.Municipality)
                .AsQueryable();

            if (!string.IsNullOrEmpty(municipality))
            { 
                query = query.Where(l => l.Municipality.Name == municipality);
            }

            if (!string.IsNullOrEmpty(category) && Enum.TryParse<Category>(category, out var categoryEnum))
            {
                query = query.Where(l => l.Category == categoryEnum);
            }

            query = (sortBy?.ToLower()) switch
                {
                    "price" => query.OrderBy(l => l.Price),
                    "price_desc" => query.OrderByDescending(l => l.Price),
                    _ => query.OrderByDescending(l => l.Id)
                };

            int totalCount = await query.CountAsync();

            var listings = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Include(l => l.Realtor)
                .ToListAsync();

            return (listings, totalCount);
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

        // Author: Conny
        public async Task<List<Listing>> GetListingsByRealtorAsync(string id)
        {
            return await _ctx.Listings
                .Include(l => l.Municipality)
                .Where(l => l.RealtorId == id)
                .ToListAsync();
        }
    }
}
