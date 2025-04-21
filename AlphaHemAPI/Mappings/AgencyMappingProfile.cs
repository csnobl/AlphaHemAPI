using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AutoMapper;

namespace AlphaHemAPI.Mappings
{
    //Author: Mattias
    public class AgencyMappingProfile :Profile
    {
        public AgencyMappingProfile()
        {
            CreateMap<Realtor, RealtorDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<Agency, AgencyWithRealtorsDto>();
        }
    }
}
