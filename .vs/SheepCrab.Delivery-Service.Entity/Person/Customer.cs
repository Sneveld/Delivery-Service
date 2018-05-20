using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer:Person
    {
        public Guid? OrganizationId { get; set; }
        [Display(Name = "Организация")]
        public virtual Organization Organization { get; set; }
    }
}
