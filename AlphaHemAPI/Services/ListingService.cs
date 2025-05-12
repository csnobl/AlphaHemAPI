using System.Net;
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
        public async Task<Response<PagedListingListDto>> GetPagedListingsAsync(
            int pageIndex,
            int pageSize,
            string? municipality = null,
            string? category = null,
            string? sortBy = null)
        {
            try
            {
                var (listings, totalCount) = await listingRepository.GetPagedListingsWithIncludesAsync(
                    pageIndex,
                    pageSize,
                    municipality,
                    category,
                    sortBy);

                var listingDtos = mapper.Map<List<ListingListDto>>(listings);

                var pagedListingListDto = mapper.Map<PagedListingListDto>(listingDtos);

                pagedListingListDto.TotalCount = totalCount;

                // Author: ALL
                return new Response<PagedListingListDto>
                {
                    Data = pagedListingListDto,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<PagedListingListDto>
                {
                    Data = null,
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
        // Author: Smilla
        // Co-author: ALL
        public async Task<Response<ListingDetailsDto>> GetListingDetailsAsync(int id)
        {
            try
            {
                var listing = await listingRepository.GetByIdWithIncludesAsync(id);
                if (listing == null)
                {
                    return new Response<ListingDetailsDto>
                    {
                        Data = null,
                        Message = "Ett fel har inträffat vid hämtning av bostad.",
                        Errors = new List<string> { $"Felmeddelande: Ingen bostad med ID: {id} kunde hittas." },
                        StatusCode = HttpStatusCode.NotFound
                    };
                }
                var listingDto = mapper.Map<ListingDetailsDto>(listing);

                return new Response<ListingDetailsDto>
                {
                    Data = listingDto,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<ListingDetailsDto>
                {
                    Data = null,
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        // Author: Conny
        // Co-author: ALL
        public async Task<Response> AddListingAsync(ListingCreateDto listingCreateDto)
        {
            try
            {
                // Map DTO -> Model
                var listing = mapper.Map<Listing>(listingCreateDto);

                // Fetch related entities using DTO IDs to set navigation properties
                var realtor = await realtorRepository.GetAsync(listingCreateDto.RealtorId);
                var municipality = await municipalityRepository.GetAsync(listingCreateDto.MunicipalityId);

                if (realtor == null)
                    return new Response
                    {
                        Message = "Ett fel har inträffat vid skapandet av bostad.",
                        Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {listingCreateDto.RealtorId}." },
                        StatusCode = HttpStatusCode.BadRequest
                    };

                if (municipality == null)
                    return new Response
                    {
                        Message = "Ett fel har inträffat vid skapandet av bostad.",
                        Errors = new List<string> { $"Ingen kommun kunde hittas med ID: {listingCreateDto.MunicipalityId}." },
                        StatusCode = HttpStatusCode.BadRequest
                    };

                listing.Realtor = realtor;
                listing.Municipality = municipality;

                await listingRepository.AddAsync(listing);

                return new Response
                {
                    StatusCode = HttpStatusCode.Created
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

        }

        // Author: Conny
        public async Task<Response> UpdateListingAsync(int id, ListingUpdateDto listingUpdateDto)
        {
            try
            {
                // Fetch listing to be updated
                var listing = await listingRepository.GetAsync(id);
                if (listing == null)
                    return new Response
                    {
                        Message = "Ett fel inträffade vid uppdatering av bostad.",
                        Errors = new List<string> { $"Ingen bostad kunde hittas med ID: {id}." },
                        StatusCode = HttpStatusCode.BadRequest
                    };

                // Fetch related entities using DTO ID to set navigation property (in case of realtor change)
                var realtor = await realtorRepository.GetAsync(listingUpdateDto.RealtorId);
                if (realtor == null)
                {
                    return new Response
                    {
                        Message = "Ett fel inträffade vid uppdatering av bostad.",
                        Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {listingUpdateDto.RealtorId}." },
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                // Map DTO -> Entity
                mapper.Map(listingUpdateDto, listing);
                listing.Realtor = realtor;

                await listingRepository.UpdateAsync(listing);

                return new Response
                {
                    StatusCode = HttpStatusCode.NoContent
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        // Author: Niklas
        // Co-author: ALL
        public async Task<Response> DeleteListingAsync(int id)
        {
            try
            {
                var listing = await listingRepository.GetAsync(id);
                if (listing == null)
                    return new Response
                    {
                        Message = "Ett fel har inträffat vid borttagning av bostad.",
                        Errors = new List<string> { $"Ingen bostad kunde hittas med ID: {id}." },
                        StatusCode = HttpStatusCode.BadRequest
                    };

                await listingRepository.DeleteAsync(listing);
                return new Response
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        // Author: Conny
        public async Task<Response<List<ListingListDto>>> GetListingsByRealtorAsync(string realtorId)
        {
            try
            {
                var listings = await listingRepository.GetListingsByRealtorAsync(realtorId);
                var listingDtos = mapper.Map<List<ListingListDto>>(listings);

                return new Response<List<ListingListDto>>
                {
                    Data = listingDtos,
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<List<ListingListDto>>
                {
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
