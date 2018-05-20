using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Person
    {
        public Guid ID { get; set; }
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        [Display(Name = "Имя")]
        public string MiddleName { get; set; }
        [Display(Name = "Отчество")]
        public string LastName { get; set; }
        [Display(Name = "Номер")]
        public string Number { get; set; }

    }
}
