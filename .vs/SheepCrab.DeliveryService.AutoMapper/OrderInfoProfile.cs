using AutoMapper;
using Entity;
using SheepCrab.DeliveryService.Dto.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.AutoMapper
{
    public class OrderInfoProfile: Profile
    {
        public OrderInfoProfile()
        {
            CreateMap<OrderInfo, OrderInfoDto>();
            CreateMap<OrderInfoDto, OrderInfo>();
        }
    }
}
