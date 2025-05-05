using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    // Author : Niklas
    // Co-Author : Dominika
    // Co-Author : Smilla
    public interface IRealtorRepository :IRepository<Realtor>
    {
        Task<Realtor?> GetByEmailAsync(string email);
        Task<List<Realtor>> GetAllWithAgencyAsync();
        Task<Realtor?> GetAsync(string id);
        Task<Realtor?> GetByIdWithAgencyAsync(string id);
    }
}
