using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AutoMapper;

namespace AlphaHemAPI.Mappings
{
    public class RealtorProfile : Profile
    {
        //Author : Dominika
        public RealtorProfile()
        {
            CreateMap<Realtor, RealtorDto>()
                .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src.Agency.Name))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
