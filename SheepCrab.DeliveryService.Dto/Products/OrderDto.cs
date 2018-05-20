using SheepCrab.DeliveryService.Dto.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SheepCrab.DeliveryService.Dto.Products
{
    public class OrderDto
    {
        public OrderDto()
        {
            Items = new List<OrderItemDto>();
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
        public List<OrderItemDto> Items { get; set; }

        public string PersonName { get; set; }

        public Guid? OrderInfoId { get; set; }
        [Display(Name = "информация о заказе")]
        public OrderInfoDto OrderInfo { get; set; }

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
        public void AddProduct(ProductDto product, int count)
        {
            var item = Items.FirstOrDefault(c => c.Product.ID == product.ID);
            if (item == null)
            {
                Items.Add(new OrderItemDto() { ID = Guid.NewGuid(), Product = product, Count = count, Mass = product.NominalMass });
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
        public OrderItemDto AddCount(Guid productId, int count)
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
    }
}
