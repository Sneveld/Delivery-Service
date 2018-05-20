using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderPoint
    {
        public Guid ID { get; set; }
        public int Index { get; set; }
        //Название
        [Display(Name = "Название")]
        public string Name { get; set; }
        //Адрес
        [Display(Name = "Адрес")]
        public string FullAdress { get; set; }
        //Широта
        [Display(Name = "Широта")]
        public string Latitude { get; set; }
        //Долгота
        [Display(Name = "Долгота")]
        public string Longitude { get; set; }
    }
}
