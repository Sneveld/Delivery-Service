using Microsoft.Extensions.DependencyInjection;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.DataAccess.DI
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ILandingPageImagesRepository, LandingPageImagesRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
        }
    }
}
