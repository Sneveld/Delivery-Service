using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.LandingPage
{
    public class LandingPageImage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Порядковый номер")]
        public int Index { get; set; }
        [Required]
        [Display(Name = "Заглавное название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }
    }
}
