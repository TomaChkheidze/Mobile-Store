using AutoMapper;
using Mobile_Store.Models;
using Mobile_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Phone, PhoneViewModel>()
                .ForMember(dest => dest.BrandName,
                opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Picture,
                opt => opt.MapFrom(src => src.Media[0]));
            //CreateMap<Phone, MobilePhoneDetailsViewModel>();
        }
    }
}
