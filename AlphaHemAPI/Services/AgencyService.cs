using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;

namespace AlphaHemAPI.Services
{
    public class AgencyService
    {
        private readonly IRepository<Agency> agencyRepository;

        public AgencyService(IRepository<Agency> agencyRepository)
        {
            this.agencyRepository = agencyRepository;
        }
    }
}
