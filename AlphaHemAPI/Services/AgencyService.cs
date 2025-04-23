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
        public async Task<AgencyWithRealtorsDto> GetAgencyById(int id)
        {
            var agency = await agencyRepository.GetAsyncIncludeRealtor(id);
            if (agency == null)
            {
                return null;
            }
            return mapper.Map<AgencyWithRealtorsDto>(agency);
        }
        //Author: Mattias
        public async Task<IEnumerable<AgencyWithRealtorsDto>> GetAllAgencies()
        {
            var agencies = await agencyRepository.GetAllAsyncIncludeRealtor();
            if (agencies == null)
            {
                return null;
            }
            return mapper.Map<IEnumerable<AgencyWithRealtorsDto>>(agencies);
        }

    }
}
