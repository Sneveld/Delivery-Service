using AutoMapper;
using Entity;
using SheepCrab.DeliveryService.Dto.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.AutoMapper
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
