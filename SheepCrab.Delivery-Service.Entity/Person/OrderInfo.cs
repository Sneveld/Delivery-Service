﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// Информация о локации заказа
    /// </summary>
    public class OrderInfo
    {
        public Guid ID { get; set; }
        [Display(Name = "Контактный номер")]
        public string Number { get; set; }
        [Display(Name = "Город")]
        public string City { get; set; }
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Display(Name = "Дом")]
        public string HouseNumber { get; set; }
        [Display(Name = "Квартира")]
        public string Apartment { get; set; }
        [Display(Name = "Этаж")]
        public string Floor { get; set; }
        [Display(Name = "Контактное лицо")]
        public string Name { get; set; }

      //  public Collection<Order> Orders { get; set; }

        public string FullAdress
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(City);
                sb.Append(" ");
                sb.Append(Street);
                sb.Append(" ");
                sb.Append(HouseNumber);
                return sb.ToString();
            }
        }
    }
}
