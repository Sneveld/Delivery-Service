using SheepCrab.DeliveryService.Dto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SheepCrab.DeliveryService.Dto.Products
{
    public class ProductDto
    {
        public Guid ID { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Тип упаковки")]
        public AccountTypeDto AccountType { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Масса")]
        public double? NominalMass { get; set; }
        [Display(Name = "Категория")]
        public virtual CategoryDto Category { get; set; }
        public Guid? CategoryId { get; set; }
        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }
    }
}
