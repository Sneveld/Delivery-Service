using AutoMapper;
using Entity.LandingPage;
using SheepCrab.DeliveryService.Dto.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.AutoMapper
{
    public class LandingPageImageProfile:Profile
    {
        public LandingPageImageProfile()
        {
            CreateMap<LandingPageImage, LandingPageImageViewModel>().
                ForMember(dest => dest.Image, opt =>opt.MapFrom(src => Convert.ToBase64String(src.Image)));
            CreateMap<LandingPageImageViewModel, LandingPageImage>();
        }
    }
}
