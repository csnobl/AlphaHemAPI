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
        private readonly IRepository<Municipality> municipalityRepository;
        private readonly IRepository<Realtor> realtorRepository;

        public ListingService(IListingRepository listingRepository, IMapper mapper, IRepository<Municipality> municipalityRepository, IRepository<Realtor> realtorRepository)
        {
            this.listingRepository = listingRepository;
            this.mapper = mapper;
            this.municipalityRepository = municipalityRepository;
            this.realtorRepository = realtorRepository;
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

        // Author: Conny
        public async Task<bool> AddListingAsync(ListingCreateDto listingCreateDto)
        {
            // Map DTO -> Model
            var listing = mapper.Map<Listing>(listingCreateDto);

            // Fetch related entities using DTO IDs to set navigation properties
            var realtor = await realtorRepository.GetAsync(listingCreateDto.RealtorId);
            var municipality = await municipalityRepository.GetAsync(listingCreateDto.MunicipalityId);

            if (realtor == null || municipality == null)
                return false;

            listing.Realtor = realtor;
            listing.Municipality = municipality;

            try
            {
                await listingRepository.AddAsync(listing);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
