using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Repositories;
using AutoMapper;
using System.Net;

namespace AlphaHemAPI.Services
{
    //Author: ALL
    public class MunicipalityService
    {
        private readonly IRepository<Municipality> municipalityRepository;
        private readonly IMapper mapper;


        //Co-Author: Christoffer
        public MunicipalityService(IRepository<Municipality> municipalityRepository, IMapper mapper)
        {
            this.municipalityRepository = municipalityRepository;
            this.mapper = mapper;
        }

        //Author: Christoffer
        // Co-author: ALL
        public async Task<Response<List<MunicipalityListDto>>> GetAllMunicipalitiesAsync()
        {
            try
            {
                var municipalities = await municipalityRepository.GetAllAsync();
                var municipalitiesDto = mapper.Map<List<MunicipalityListDto>>(municipalities);

                return new Response<List<MunicipalityListDto>>
                {
                    Data = municipalitiesDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<MunicipalityListDto>>
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
