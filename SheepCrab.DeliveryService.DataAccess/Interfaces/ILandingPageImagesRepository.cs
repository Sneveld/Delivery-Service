using Entity.LandingPage;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.DataAccess.Interfaces
{
    public interface ILandingPageImagesRepository
    {
        IEnumerable<LandingPageImage> GetAll();
    }
}
