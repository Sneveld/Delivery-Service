using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}
