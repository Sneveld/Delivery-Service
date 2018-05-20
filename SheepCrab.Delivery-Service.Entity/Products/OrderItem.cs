using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Enums;

namespace Entity
{
    public class OrderItem
    {
        public Guid ID { get; set; }
        public Product Product { get; set; }
        public double? Mass { get; set; }
        public int? Count { get; set; }

        public double Price
        {
            get
            {
                if (Product.AccountType == AccountType.kilogram && Mass!=null)
                    return (double)Mass*Product.Price;
                if (Product.AccountType == AccountType.number && Count != null)
                    return (int)Count * Product.Price;
                return 0;
            }
        }
    }
}
