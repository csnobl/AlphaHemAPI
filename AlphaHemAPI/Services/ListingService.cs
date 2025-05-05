using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class ListingService
    {
        private readonly IListingRepository listingRepository;
        private readonly IMapper mapper;
        private readonly IRepository<Municipality> municipalityRepository;
        private readonly IRealtorRepository realtorRepository;

        public ListingService(IListingRepository listingRepository, IMapper mapper, IRepository<Municipality> municipalityRepository, IRealtorRepository realtorRepository)
        {
            this.listingRepository = listingRepository;
            this.mapper = mapper;
            this.municipalityRepository = municipalityRepository;
            this.realtorRepository = realtorRepository;
        }

        // Author : Smilla
        // Co-author: Christoffer
        public async Task<PagedListingListDto> GetPagedListingsAsync(int pageIndex, int pageSize, string? municipality = null, string? sortBy = null)
        {
            try
            {
                var (listings, totalCount) = await listingRepository.GetPagedListingsWithIncludesAsync(pageIndex, pageSize, municipality, sortBy);

                var listingDtos = mapper.Map<List<ListingListDto>>(listings);

                var pagedListingListDto = mapper.Map<PagedListingListDto>(listingDtos);

                pagedListingListDto.TotalCount = totalCount;
                pagedListingListDto.PageSize = pageSize;
                pagedListingListDto.CurrentPage = pageIndex;

                return pagedListingListDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching listings.", ex);
            }

        }

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

        // Author: Conny
        public async Task<bool> UpdateListingAsync(int id, ListingUpdateDto listingUpdateDto)
        {
            // Fetch listing to be updated
            var listing = await listingRepository.GetAsync(id);
            if (listing == null)
                return false;

            // Map DTO -> Entity
            mapper.Map(listingUpdateDto, listing);

            // Fetch related entities using DTO ID to set navigation property (in case of realtor change)
            var realtor = await realtorRepository.GetAsync(listingUpdateDto.RealtorId);

            if (realtor == null)
                return false;

            listing.Realtor = realtor;

            try
            {
                await listingRepository.UpdateAsync(listing);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Author: Niklas
        public async Task<bool> DeleteListingAsync(int id)
        {

            var listing = await listingRepository.GetAsync(id);
            if (listing == null)
                return false;

            try
            {
                await listingRepository.DeleteAsync(listing);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Author: Conny
        public async Task<List<ListingListDto>> GetListingsByRealtorAsync(string realtorId)
        {
            var listings = await listingRepository.GetListingsByRealtorAsync(realtorId);

            var listingDtos = mapper.Map<List<ListingListDto>>(listings);

            return listingDtos;
        }
    }
}
