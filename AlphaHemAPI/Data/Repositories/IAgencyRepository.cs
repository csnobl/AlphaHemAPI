using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    //Author : Mattias
    public interface IAgencyRepository :IRepository<Agency>
    {
        new Task<Agency?> GetAsyncIncludeRealtor(int id);
    }
}
