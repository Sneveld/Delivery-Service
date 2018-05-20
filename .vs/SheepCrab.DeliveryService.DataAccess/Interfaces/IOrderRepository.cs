using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        void SaveOrder(Order ord);
        OrderInfo GetOrderInfoByNumber(string number);
        Order GetNewOrder();
    }
}
