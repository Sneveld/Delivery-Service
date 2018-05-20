using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Organization
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Адресс")]
        public string LegalAdress { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public ICollection<Point> Points { get; set; }
        public ICollection<Customer> Customers { get; set; } 
    }
}
