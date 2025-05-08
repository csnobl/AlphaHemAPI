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

        // Author : Niklas
        public async Task<bool> RegisterRealtorAsync(RealtorRegisterDto registerDto)
        {
            var existing = await realtorRepository.GetByEmailAsync(registerDto.Email);
            if (existing != null)
                return false;

            var realtor = new Realtor
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
                AgencyId = registerDto.AgencyId,
                ProfilePicture = "",
            };

            await realtorRepository.AddAsync(realtor);
            return true;
        }

        //Author: Christoffer
        public async Task<bool> UpdateRealtorAsync(string id, RealtorUpdateDto realtorUpdateDto)
        {
            var realtor = await realtorRepository.GetAsync(id);
            if (realtor == null)
                return false;

            mapper.Map(realtorUpdateDto, realtor);

            try
            {
                await realtorRepository.UpdateAsync(realtor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Author : Dominika
        public async Task<List<RealtorDto>> GetAllRealtorsAsync()
        {
            var realtors = await realtorRepository.GetAllWithAgencyAsync();
            return mapper.Map<List<RealtorDto>>(realtors);
        }

        //Author : Smilla
        public async Task<RealtorDto?> GetRealtorByIdAsync(string id)
        {
            var realtor = await realtorRepository.GetByIdWithAgencyAsync(id);
            if (realtor == null)
                return null;
            return mapper.Map<RealtorDto>(realtor);
        }

        //Author : ALL
        public async Task<bool> ApproveEmailForRealtorAsync(string userId, string adminId)
        {
            var adminRealtor = await realtorRepository.GetAsync(adminId);
            if (adminRealtor == null)
                return false;

            var realtor = await realtorRepository.GetAsync(userId);
            if (realtor == null || realtor.EmailConfirmed)
                return false;

            if (realtor.AgencyId != adminRealtor.AgencyId)
                return false;

            realtor.EmailConfirmed = true;
            try
            {
                await realtorRepository.UpdateAsync(realtor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Author: Conny
        public async Task<Response> DeleteRealtorAsync(string userId, string adminId)
        {
            var adminRealtor = await realtorRepository.GetAsync(adminId);
            var realtor = await realtorRepository.GetAsync(userId);

            if (realtor == null)
            {
                return new Response
                {
                    Message = "Ett fel har uppstått vid hämtning av mäklare.",
                    Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {userId}." },
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            if (adminRealtor == null)
            {
                return new Response
                {
                    Message = "Ett fel har uppstått vid hämtning av mäklaradministratör.",
                    Errors = new List<string> { $"Ingen mäklare kunde hittas med ID: {adminId}." },
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            if (realtor.AgencyId != adminRealtor.AgencyId)
            {
                return new Response
                {
                    Message = "Ett fel har uppstått vid borttagning av mäklare",
                    Errors = new List<string> { $"De angivna mäklarna tillhör inte samma mäklarbyrå (adminRealtor.AgencyId = {adminRealtor.AgencyId}, realtor.AgencyId = {realtor.AgencyId})." },
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            try
            {
                await realtorRepository.DeleteAsync(realtor);
                return new Response
                {
                    Success = true,
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
