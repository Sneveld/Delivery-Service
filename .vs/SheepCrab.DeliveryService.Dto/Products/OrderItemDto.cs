using SheepCrab.DeliveryService.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.Dto.Products
{
    public class OrderItemDto
    {
        public Guid ID { get; set; }
        public ProductDto Product { get; set; }
        public double? Mass { get; set; }
        public int? Count { get; set; }

        public double Price
        {
            get
            {
                if (Product.AccountType == AccountTypeDto.kilogram && Mass != null)
                    return (double)Mass * Product.Price;
                if (Product.AccountType == AccountTypeDto.number && Count != null)
                    return (int)Count * Product.Price;
                return 0;
            }
        }
    }
}
