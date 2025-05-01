using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    // Author : Smilla
    // Co-author: Conny, Christoffer
    public interface IListingRepository : IRepository<Listing>
    {
        Task<(List<Listing> Listings, int TotalCount)> GetPagedListingsWithIncludesAsync(
            int pageIndex,
            int pageSize,
            string? municipality = null,
            string? sortBy = null);
        Task<Listing?> GetByIdWithIncludesAsync(int id);
        Task<List<Listing>> GetListingsByRealtorAsync(string id);
    }
}