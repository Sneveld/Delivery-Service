using Microsoft.Extensions.DependencyInjection;
using SheepCrab.DeliveryService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.Model.DI
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMainMenuService, MainMenuService>();
            services.AddTransient<ILandingPageService, LandingPageService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductsService, ProductsService>();
        }
    }
}
