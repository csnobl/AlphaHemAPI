using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AutoMapper;

namespace AlphaHemAPI.Mappings
{
    //Author: Mattias
    // Co-author: Conny
    public class AgencyMappingProfile :Profile
    {
        public AgencyMappingProfile()
        {
            CreateMap<Agency, AgencyWithRealtorsDto>();
        }
    }
}
