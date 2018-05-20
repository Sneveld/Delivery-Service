using SheepCrab.DeliveryService.Dto.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.Model.Interfaces
{
    public interface ILandingPageService
    {
        IEnumerable<LandingPageImageViewModel> GetAllLandingPageImages();
    }
}
