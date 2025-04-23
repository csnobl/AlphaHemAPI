using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    // Author : Niklas
    // Co-Author : Dominika
    public interface IRealtorRepository :IRepository<Realtor>
    {
        Task<Realtor?> GetByEmailAsync(string email);
        Task<List<Realtor>> GetAllWithAgencyAsync();
    }
}
