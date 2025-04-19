using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    // Author : Smilla
    // Co-author: Conny
    // Co-author: Christoffer
    public interface IListingRepository : IRepository<Listing>
    {
        Task<List<Listing>> GetAllWithIncludesAsync(string? municipality = null);
        Task<Listing?> GetByIdWithIncludesAsync(int id);
    }
}
