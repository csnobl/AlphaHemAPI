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
            // Mapping for list of listing
            CreateMap<Listing, ListingListDto>()
                .ForMember(d => d.Municipality,
                           o => o.MapFrom(s => s.Municipality.Name))
                .ForMember(d => d.RealtorFullName,
                           o => o.MapFrom(s => s.Realtor.FirstName + " " + s.Realtor.LastName))
                .ForMember(d => d.Category,
                           o => o.MapFrom(s => s.Category.ToString()));

            // Mapping for details of listing
            CreateMap<Listing, ListingDetailsDto>()
                .ForMember(d => d.MunicipalityName,
                           o => o.MapFrom(s => s.Municipality.Name))
                .ForMember(d => d.Category,
                           o => o.MapFrom(s => s.Category.ToString()))
                .ForMember(d => d.Realtor,
                           o => o.MapFrom(s => s.Realtor));

            // Mapping for realtor-info and agency-info in details of listing
            CreateMap<Realtor, RealtorInListingDto>()
                .ForMember(d => d.FullName,
                           o => o.MapFrom(s => s.FirstName + " " + s.LastName))
                .ForMember(d => d.AgencyName,
                           o => o.MapFrom(s => s.Agency.Name))
                .ForMember(d => d.AgencyLogo,
                           o => o.MapFrom(s => s.Agency.Logo));

            // Author: Conny
            // Mapping for creating a listing
            CreateMap<ListingCreateDto, Listing>();

            // Author: Conny
            // Mapping for updating a listing. Can also be used to map fetched data when sending to client for a listing update page
            CreateMap<ListingUpdateDto, Listing>()
                .ReverseMap();

            //Author: Christoffer
            CreateMap<RealtorUpdateDto, Realtor>()
                .ReverseMap();

            //Author: Christoffer
            CreateMap<Municipality, MunicipalityListDto>();
        }
    }
}
