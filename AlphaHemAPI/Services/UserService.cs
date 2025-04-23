using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class UserService
    {
        private readonly IRepository<Realtor> realtorRepository;
        private readonly IListingRepository listingRepository;
        private readonly IAgencyRepository agencyRepository;
        private readonly IRepository<Municipality> municipalityRepository;

        public UserService(IRepository<Realtor> realtorRepository, IListingRepository listingRepository, IAgencyRepository agencyRepository, IRepository<Municipality> municipalityRepository)
        {
            this.realtorRepository = realtorRepository;
            this.listingRepository = listingRepository;
            this.agencyRepository = agencyRepository;
            this.municipalityRepository = municipalityRepository;
        }
    }
}
