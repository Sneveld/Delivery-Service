
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SheepCrab.Delivery_Service.ClientModule.Extensions;
using SheepCrab.DeliveryService.Dto.Person;
using SheepCrab.DeliveryService.Dto.Products;
using SheepCrab.DeliveryService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheepCrab.Delivery_Service.ClientModule.Controllers
{
    public class ChartController : Controller
    {
        public ChartController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private readonly IOrderService _orderService;

       
        [HttpPost]
        public void SetCount([FromBody]AddProductsDto addProductsDto)
        {
            var order = GetOrder();
            order.AddCount(new Guid(addProductsDto.ProductId), addProductsDto.Count);
            HttpContext.Session.SetObject<OrderDto>("Order", order);
        }

        [HttpPost]
        public void SaveOrder([FromBody]OrderDto ord)
        {
            if (ord.Items.Count > 0)
            {
                _orderService.SaveOrder(ord);
                ResetOrder();
            }
        }        

        [HttpGet]
        public double GetOrderSum()
        {
            return GetOrder().SummPrice;
        }
        [HttpGet]
        public OrderInfoDto GetOrderInfoByNumber(string number)
        {
            var orderInfo = _orderService.GetOrderInfoByNumber(number);          
            return orderInfo;
        }
        [HttpGet]
        public OrderDto GetCurrnetOrder()
        {
            var order = GetOrder();
            return order;
        }
        private void ResetOrder()
        {
            HttpContext.Session.SetObject<Order>("Order", null);
        }

        private OrderDto GetOrder()
        {
            OrderDto order = HttpContext.Session.GetObject<OrderDto>("Order");
            if (order == null)
            {
                order = _orderService.GetNewOrder();
                HttpContext.Session.SetObject<OrderDto>("Order", order);
            }
            return order;
        }
    }
}
