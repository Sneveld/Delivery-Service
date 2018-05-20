using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category
    {
        [Key]
        public Guid ID { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Дочерние категории")]
        public virtual ICollection<Category> ChildCategories { get; set; }

        [Display(Name = "Родительская категория")]
        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }
        public Guid? ParentCategoryId { get; set; }
        [Display(Name = "Продукты")]
        public virtual ICollection<Product> Products { get; set; } 

    }
}
