using System.Net;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;
using AutoMapper;

namespace AlphaHemAPI.Services
{
    public class AgencyService
    {
        private readonly IAgencyRepository agencyRepository;
        private readonly IMapper mapper;
        private readonly IRealtorRepository realtorRepository;

        public AgencyService(IAgencyRepository agencyRepository, IMapper mapper, IRealtorRepository realtorRepository)
        {
            this.agencyRepository = agencyRepository;
            this.mapper = mapper;
            this.realtorRepository = realtorRepository;
        }

        //Author: Mattias
        // Co-author: ALL
        public async Task<Response<AgencyWithRealtorsDto>> GetAgencyById(int id)
        {
            try
            {
                var agency = await agencyRepository.GetAsyncIncludeRealtor(id);
                if (agency == null)
                {
                    return new Response<AgencyWithRealtorsDto>
                    {
                        Message = $"Kunde inte hitta en mäklarbyrå med ID: {id}",
                        // Errors = ...
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                var agencyDto = mapper.Map<AgencyWithRealtorsDto>(agency);
                return new Response<AgencyWithRealtorsDto>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = agencyDto
                };
            }
            catch (Exception ex)
            {
                return new Response<AgencyWithRealtorsDto>
                {
                    Data = null,
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
        
        //Author: Mattias
        // Co-author: ALL
        public async Task<Response<List<AgencyWithRealtorsDto>>> GetAllAgencies()
        {
            try
            {
                var agencies = await agencyRepository.GetAllAsyncIncludeRealtor();
                var agencyList = mapper.Map<List<AgencyWithRealtorsDto>>(agencies);

                return new Response<List<AgencyWithRealtorsDto>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = agencyList
                };
            }
            catch (Exception ex)
            {
                return new Response<List<AgencyWithRealtorsDto>>
                {
                    Data = null,
                    Message = "Ett oväntat fel har inträffat.",
                    Errors = new List<string> { $"Felmeddelande: {ex.Message}" },
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        //Author: Mattias
        public async Task<Response> UpdateAgency(string adminId,AgencyUpdateDto agencyUpdateDto)
        {
            try
            {
                var agency = await agencyRepository.GetAsync(agencyUpdateDto.Id);
                if (agency == null)
                {
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Ett fel har inträffat vid uppdatering av byrå.",
                        Errors = new List<string> { $"Ingen byrå kunde hittas med ID: {agencyUpdateDto.Id}." }
                    };
                }
                var adminRealtor = await realtorRepository.GetAsync(adminId);
                if (adminRealtor.AgencyId != agency.Id)
                    return new Response
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Message = "Ett fel har inträffat vid uppdatering av byrå.",
                        Errors = new List<string> { $"Du har inte behörighet att ändra byrån med ID: {agency.Id}." }
                    };

                mapper.Map(agencyUpdateDto, agency);
                await agencyRepository.UpdateAsync(agency);

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

    }
}
