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

        public AgencyService(IAgencyRepository agencyRepository, IMapper mapper)
        {
            this.agencyRepository = agencyRepository;
            this.mapper = mapper;
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
                        StatusCode = HttpStatusCode.NotFound,
                        Data = null
                    };
                }
                var agencyDto = mapper.Map<AgencyWithRealtorsDto>(agency);
                return new Response<AgencyWithRealtorsDto>
                {
                    Success = true,
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
                    Success = true,
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

    }
}
