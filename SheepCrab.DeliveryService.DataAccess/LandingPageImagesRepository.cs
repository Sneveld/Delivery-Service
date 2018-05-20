using DataContext;
using Entity.LandingPage;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheepCrab.DeliveryService.DataAccess
{
    public class LandingPageImagesRepository: ILandingPageImagesRepository
    {
        public LandingPageImagesRepository(ModelContext modelContext)
        {
            db = modelContext;
        }

        private ModelContext db;

        public IEnumerable<LandingPageImage> GetAll()
        {
            return db.LandingPageImages.ToList();
        }
    }
}
