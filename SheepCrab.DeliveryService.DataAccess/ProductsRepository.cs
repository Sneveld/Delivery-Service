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
    public class ProductsRepository: IProductsRepository
    {
        public ProductsRepository(ModelContext modelContext)
        {
            db = modelContext;
        }

        private ModelContext db;

        public Product FindProduct(Guid productId)
        {
            return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.Include(c => c.Category).ToList();
        }
    }
}
