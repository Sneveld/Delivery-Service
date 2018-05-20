using System;
using Microsoft.EntityFrameworkCore;
using Entity;
using Entity.LandingPage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataContext
{
    public class ModelContext: IdentityDbContext<ApplicationUser>
    {
        public ModelContext()
        {
            
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
            
        }

      

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public DbSet<Organization> Organizations { get; set; } 
        public DbSet<LandingPageImage> LandingPageImages { get; set; }
        public DbSet<OrderPoint> OrderPoints { get; set; }
        public DbSet<OrderInfo> OrderInfoes { get; set; }

    }
}
