using AlphaHemAPI.Data.Models;
using AlphaHemAPI.Data.Repositories;

namespace AlphaHemAPI.Services
{
    public class MunicipalityService
    {
        private readonly IRepository<Municipality> municipalityRepository;

        public MunicipalityService(IRepository<Municipality> municipalityRepository)
        {
            this.municipalityRepository = municipalityRepository;
        }
    }
}
