﻿using AutoMapper;
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

            CreateMap<Domain.Entities.BikeWorkshop, BikeWorkshopDto>()
                .ForMember(dst => dst.PhoneNumber,  opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dst => dst.Street,       opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dst => dst.City,         opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dst => dst.PostalCode,   opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dst => dst.PhoneNumber,  opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));
        }
    }
}
