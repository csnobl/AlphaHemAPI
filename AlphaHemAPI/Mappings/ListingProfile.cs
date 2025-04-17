using AlphaHemAPI.Data.DTO;
using AlphaHemAPI.Data.Models;
using AutoMapper;

namespace AlphaHemAPI.Mappings
{
    // Author : Smilla
    public class ListingProfile : Profile
    {
        public ListingProfile()
        {
            // Mapping for the list of listings
            CreateMap<Listing, ListingListDto>()
            .ForMember(d => d.Municipality,
                       o => o.MapFrom(s => s.Municipality.Name))
            .ForMember(d => d.RealtorFullName,
                       o => o.MapFrom(s => s.Realtor.FirstName + " " + s.Realtor.LastName))
            .ForMember(d => d.Category,
                       o => o.MapFrom(s => s.Category.ToString()));
        }
    }
}

