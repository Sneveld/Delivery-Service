using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }
        public Guid ID { get; set; }
        [Display(Name = "Время заказа")]
        [DataType(DataType.DateTime)]
        public DateTime OrderTime { get; set; }
        [Display(Name = "Назначенное время")]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryTime { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Согласовано")]
        public bool IsCorrect { get; set; }
        [Display(Name = "Позиции")]
        public List<OrderItem> Items { get; set; }
        [Display(Name = "Покупатель")]
        public Customer Customer { get; set; }
        public Guid? CustomerId { get; set; }

        public string PersonName { get; set; }

        public Guid? OrderPointId { get; set; }
        public OrderPoint OrderPoint { get; set; }

        public Guid? OrderInfoId { get; set; }
        [Display(Name = "информация о заказе")]
        public OrderInfo OrderInfo { get; set; }

        [Display(Name = "Принят в обработку (распечатан)")]
        public bool IsPrint { get; set; }

        public double SummPrice
        {
            get
            {
                return Items.Sum(c => c.Price);
            }
        }

        //TODO in separate service
        public void AddProduct(Product product, int count)
        {
            var item = Items.FirstOrDefault(c => c.Product.ID == product.ID);
            if (item == null)
            {
                Items.Add(new OrderItem() { ID = Guid.NewGuid(), Product = product, Count = count, Mass = product.NominalMass });
            }
            else
            {
                item.Count += count;
                if (item.Product.NominalMass != null)
                {
                    if (item.Mass == null)
                        item.Mass = 0;
                    item.Mass += item.Product.NominalMass * count;
                }

            }
        }
        //TODO in separate service
        public OrderItem AddCount(Guid productId, int count)
        {
            var item = Items.FirstOrDefault(c => c.Product.ID == productId);
            item.Count = count;
            if (item.Product.NominalMass != null)
            {
                if (item.Mass == null)
                    item.Mass = 0;
                item.Mass = item.Product.NominalMass * count;
            }
            return item;
        }

        public void RemoveProduct(Product product)
        {
            Items.RemoveAll(c => c.Product.ID == product.ID);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
