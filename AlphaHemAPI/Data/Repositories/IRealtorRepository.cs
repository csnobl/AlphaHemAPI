using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    // Author : Niklas
    public interface IRealtorRepository :IRepository<Realtor>
    {
        Task<Realtor?> GetByEmailAsync(string email);
    }
}
