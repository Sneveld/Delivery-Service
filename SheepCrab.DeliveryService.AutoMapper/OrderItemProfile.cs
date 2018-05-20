using AutoMapper;
using Entity;
using SheepCrab.DeliveryService.Dto.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.AutoMapper
{
    public class OrderItemProfile: Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
