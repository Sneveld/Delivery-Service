using DataContext;
using Entity;
using Microsoft.EntityFrameworkCore;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheepCrab.DeliveryService.DataAccess
{
    public class OrderRepository: IOrderRepository
    {
        private ModelContext db;

        public OrderRepository(ModelContext modelContext)
        {
            db = modelContext;
        }

        public void SaveOrder(Order ord)
        {
            ord.ID = Guid.NewGuid();
            ord.OrderTime = DateTime.UtcNow;
            ord.DeliveryTime = DateTime.UtcNow;
            //TODO entity вне контекста - зло

            if (ord.OrderInfo.ID == Guid.Empty)
            {
                ord.OrderInfo.ID = Guid.NewGuid();
            }

            foreach (var product in ord.Items.Select(c => c.Product).ToList().Distinct())
            {
                db.Entry(product).State = EntityState.Modified;
            }

            db.Orders.Add(ord);
            db.SaveChanges();
        }

        public OrderInfo GetOrderInfoByNumber(string number)
        {
            return db.OrderInfoes.FirstOrDefault(c => c.Number == number);
        }

        public Order GetNewOrder()
        {
            var order = new Order { OrderInfo = new OrderInfo() };
            return order;
        }
    }
}
