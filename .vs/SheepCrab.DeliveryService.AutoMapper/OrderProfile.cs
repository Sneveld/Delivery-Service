using AutoMapper;
using Entity;
using SheepCrab.DeliveryService.Dto.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.AutoMapper
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
