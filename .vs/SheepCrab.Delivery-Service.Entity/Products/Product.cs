using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Enums;

namespace Entity
{
    public class Product
    {
        public Product()
        {
            
        }

        [Key]
        public Guid ID { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Тип упаковки")]
        public AccountType AccountType { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Масса")]
        public double? NominalMass { get; set; }
        [Display(Name = "Категория")]
        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }
        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }


    }
}
