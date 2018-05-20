using System;
using System.ComponentModel.DataAnnotations;

namespace SheepCrab.DeliveryService.Dto.ViewModels
{
    public class LandingPageImageViewModel
    {
        public LandingPageImageViewModel()
        {

        }

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
        public string Image { get; set; }
    }
}