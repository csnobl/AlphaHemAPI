using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    // Author : Smilla
    // Co-author: Conny
    public interface IListingRepository : IRepository<Listing>
    {
        Task<List<Listing>> GetAllWithIncludesAsync();
        Task<Listing?> GetByIdWithIncludesAsync(int id);
    }
}
