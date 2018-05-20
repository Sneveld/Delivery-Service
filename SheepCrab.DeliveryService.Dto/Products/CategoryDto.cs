using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SheepCrab.DeliveryService.Dto.Products
{
    public class CategoryDto
    {
        public Guid ID { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Дочерние категории")]
        public virtual ICollection<CategoryDto> ChildCategories { get; set; }

        [Display(Name = "Родительская категория")]
        public virtual CategoryDto ParentCategory { get; set; }
        public Guid? ParentCategoryId { get; set; }
        [Display(Name = "Продукты")]
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
