using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;
using AutoMapper;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class ListingService
    {
        private readonly IListingRepository listingRepository;
        private readonly IMapper mapper;

        public ListingService(IListingRepository listingRepository, IMapper mapper)
        {
            this.listingRepository = listingRepository;
            this.mapper = mapper;
        }

        // Author : Smilla
        public async Task<List<ListingListDto>> GetAllListingsAsync()
        {
            var listings = await listingRepository.GetAllWithIncludesAsync();
            return mapper.Map<List<ListingListDto>>(listings);
        }

        // Author : Smilla
        public async Task<ListingDetailsDto> GetListingDetailsAsync(int id)
        {
            var listing = await listingRepository.GetByIdWithIncludesAsync(id);
            if (listing == null)
            {
                return null;
            }
            return mapper.Map<ListingDetailsDto>(listing);
        }
    }
}
