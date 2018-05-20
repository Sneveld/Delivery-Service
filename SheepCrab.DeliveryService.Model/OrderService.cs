using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DataContext;
using Entity;
using Microsoft.EntityFrameworkCore;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using SheepCrab.DeliveryService.Dto.Person;
using SheepCrab.DeliveryService.Dto.Products;
using SheepCrab.DeliveryService.Model.Interfaces;

namespace SheepCrab.DeliveryService.Model
{   

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public void SaveOrder(OrderDto ord)
        {
            var order = _mapper.Map<Order>(ord);
            _orderRepository.SaveOrder(order);
        }

        public OrderInfoDto GetOrderInfoByNumber(string number)
        {
            return _mapper.Map<OrderInfoDto>(_orderRepository.GetOrderInfoByNumber(number));
        }

        public OrderDto GetNewOrder()
        {            
            return _mapper.Map<OrderDto>(_orderRepository.GetNewOrder());
        }

       
    }
}