using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SheepCrab.Delivery_Service.ClientModule.Models;
using SheepCrab.Delivery_Service.ClientModule.Services;
using Entity;
using DataContext;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Newtonsoft.Json;
using AutoMapper;
using SheepCrab.DeliveryService.DataAccess;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using SheepCrab.DeliveryService.Model.Interfaces;
using SheepCrab.DeliveryService.Model;
using SheepCrab.DeliveryService.AutoMapper;
using System.Reflection;
using SheepCrab.DeliveryService.DataAccess.DI;
using SheepCrab.DeliveryService.Model.DI;

namespace SheepCrab.Delivery_Service.ClientModule
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DbInit, DbInit>();
            //DataAccess Module
            services.AddRepositories();
            //Model Module
            services.AddServices();

            services.AddDistributedMemoryCache();
            services.AddSession();

            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");

            //services.AddAutoMapper();
            services.AddAutoMapper(typeof(OrderProfile).GetTypeInfo().Assembly);

            services.AddDbContext<ModelContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ModelContext>()
                .AddDefaultTokenProviders();


            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseDeveloperExceptionPage();

            app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            {
                HotModuleReplacement = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });
        }
    }
}
