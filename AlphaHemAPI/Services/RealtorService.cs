using System.Net;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;
using AutoMapper;

namespace AlphaHemAPI.Services
{
    //Author : ALL
    public class RealtorService
    {
        private readonly IRealtorRepository realtorRepository;
        private readonly IMapper mapper;

        //Co-Author: Christoffer
        public RealtorService(IRealtorRepository realtorRepository, IMapper mapper)
        {
            this.realtorRepository = realtorRepository;
            this.mapper = mapper;
        }

        //Author: Christoffer
        public async Task<Response> UpdateRealtorAsync(string id, RealtorUpdateDto realtorUpdateDto)
        {
            try
            {
                var realtor = await realtorRepository.GetAsync(id);
                if (realtor == null)
                {
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Ett fel har inträffat vid uppdatering av mäklare.",
                        Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {id}." }
                    };
                }

                mapper.Map(realtorUpdateDto, realtor);
                await realtorRepository.UpdateAsync(realtor);

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

        //Author : Dominika
        public async Task<List<RealtorDto>> GetAllRealtorsAsync()
        {
            var realtors = await realtorRepository.GetAllWithAgencyAsync();
            return mapper.Map<List<RealtorDto>>(realtors);
        }

        //Author : Smilla
        public async Task<Response<RealtorDto?>> GetRealtorByIdAsync(string id)
        {
            try
            {
                var realtor = await realtorRepository.GetByIdWithAgencyAsync(id);
                if (realtor == null)
                {
                    return new Response<RealtorDto?>
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Ett fel har inträffat vid hämtning av mäklare.",
                        Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {id}." }
                    };
                }
                var realtorDto = mapper.Map<RealtorDto>(realtor);
                return new Response<RealtorDto?>
                {
                    Data = realtorDto,
                };
            }
            catch (Exception ex)
            {
                return new Response<RealtorDto?>
                {
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

        }

        //Author : ALL
        public async Task<Response> ApproveEmailForRealtorAsync(string userId, string adminId)
        {
            try
            {
                var adminRealtor = await realtorRepository.GetAsync(adminId);
                if (adminRealtor == null)
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Ett fel har inträffat vid aktivering av mäklare.",
                        Errors = new List<string> { $"Ingen mäklaradministratör kunde hittas med ID: {adminId}." }
                    };

                var realtor = await realtorRepository.GetAsync(userId);
                if (realtor == null)
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Ett fel har inträffat vid aktivering av mäklare.",
                        Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {adminId}." }
                    };
                if (realtor.EmailConfirmed)
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Ett fel har inträffat vid aktivering av mäklare.",
                        Errors = new List<string> { $"Mäklarens e-post är redan bekräftad." }
                    };

                if (realtor.AgencyId != adminRealtor.AgencyId)
                    return new Response
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Message = "Ett fel har inträffat vid aktivering av mäklare.",
                        Errors = new List<string> { $"Du har inte behörighet att bekräfta mäklaren med ID: {userId}." }
                    };

                realtor.EmailConfirmed = true;
                await realtorRepository.UpdateAsync(realtor);
                return new Response
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = "Ett oväntat fel uppstod vid aktivering av mäklare.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        // Author: Conny
        public async Task<Response> DeleteRealtorAsync(string userId, string adminId)
        {
            try
            {
                var adminRealtor = await realtorRepository.GetAsync(adminId);
                if (adminRealtor == null)
                {
                    return new Response
                    {
                        Message = "Ett fel har uppstått vid hämtning av mäklaradministratör.",
                        Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {adminId}." },
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                var realtor = await realtorRepository.GetAsync(userId);
                if (realtor == null)
                {
                    return new Response
                    {
                        Message = "Ett fel har uppstått vid hämtning av mäklare.",
                        Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {userId}." },
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                if (realtor.AgencyId != adminRealtor.AgencyId)
                {
                    return new Response
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Message = "Ett fel har inträffat vid borttagning av mäklare.",
                        Errors = new List<string> { $"Du har inte behörighet att ta bort mäklaren med ID: {userId}." }
                    };
                }

                await realtorRepository.DeleteAsync(realtor);
                return new Response
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = "Ett oväntat fel uppstod vid borttagning av mäklare.",
                    Errors = new List<string> { $"Error: {ex.Message}." },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
