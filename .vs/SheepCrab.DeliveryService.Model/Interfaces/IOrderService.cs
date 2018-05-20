using SheepCrab.DeliveryService.Dto.Person;
using SheepCrab.DeliveryService.Dto.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.Model.Interfaces
{
    public interface IOrderService
    {
        void SaveOrder(OrderDto ord);
        OrderInfoDto GetOrderInfoByNumber(string number);
        OrderDto GetNewOrder();
    }
}
