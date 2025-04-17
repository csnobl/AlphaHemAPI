using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class ListingService
    {
        private readonly IRepository<Listing> listingRepository;

        public ListingService(IRepository<Listing> listingRepository)
        {
            this.listingRepository = listingRepository;
        }
    }
}
