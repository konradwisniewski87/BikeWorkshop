using AutoMapper;
using BikeWorkshop.Application.BikeWorkshop;
using BikeWorkshop.Domain.Entities;

namespace BikeWorkshop.Application.Mappings
{
    public class BikeWorkshopMappingProfile : Profile
    {
        public BikeWorkshopMappingProfile()
        {
            CreateMap<BikeWorkshopDto, Domain.Entities.BikeWorkshop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new BikeWorkshopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }
            ));

        }
    }
}
