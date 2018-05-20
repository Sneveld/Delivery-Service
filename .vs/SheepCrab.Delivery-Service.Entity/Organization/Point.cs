using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Point
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
    }
}
