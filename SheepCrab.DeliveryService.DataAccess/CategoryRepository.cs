using DataContext;
using Entity;
using Microsoft.EntityFrameworkCore;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheepCrab.DeliveryService.DataAccess
{
    public class CategoryRepository: ICategoryRepository
    {
        public CategoryRepository(ModelContext modelContext)
        {
            db = modelContext;
        }

        private ModelContext db;

        public IEnumerable<Category> GetAll()
        {
            return db.Categories
                .Include(c => c.ChildCategories)
                .Include(c => c.ParentCategory)
                .Include(c => c.Products).
                ToList();
        }
    }
}
