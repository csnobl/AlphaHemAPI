using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class RealtorService
    {
        private readonly IRepository<Realtor> realtorRepository;

        public RealtorService(IRepository<Realtor> realtorRepository)
        {
            this.realtorRepository = realtorRepository;

        }
    }
}
