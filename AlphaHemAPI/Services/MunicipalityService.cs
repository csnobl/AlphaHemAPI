using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Repositories;
using AutoMapper;

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
        public async Task<List<MunicipalityListDto>> GetAllMunicipalitiesAsync()
        {
            var municipalities = await municipalityRepository.GetAllAsync();

            return mapper.Map<List<MunicipalityListDto>>(municipalities);
        }
    }
}
