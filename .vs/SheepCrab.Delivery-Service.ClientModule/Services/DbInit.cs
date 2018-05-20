using DataContext;
using Entity;
using Entity.Enums;
using Entity.LandingPage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SheepCrab.Delivery_Service.ClientModule.Services
{
    public class DbInit
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleStore;
        private readonly ModelContext dc;

        public DbInit(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleStore, ModelContext dc)
        {
            this.userManager = userManager;
            this.roleStore = roleStore;
            this.dc = dc;
        }
        public async Task InitDbAsync()
        {        
            var product1 = new Product()
            {
                ID = Guid.NewGuid(),
                AccountType = AccountType.kilogram,
                Name = "Картофель",
                Description = "",
                Price = 100
            };
            var product2 = new Product()
            {
                ID = Guid.NewGuid(),
                AccountType = AccountType.kilogram,
                Name = "Сыр",
                Description = "",
                Price = 100
            };
            var product3 = new Product()
            {
                ID = Guid.NewGuid(),
                AccountType = AccountType.kilogram,
                Name = "Рыба",
                Description = "",
                Price = 100
            };

            dc.Products.Add(product1);
            dc.Products.Add(product2);
            dc.Products.Add(product3);

            var cat1 = new Category()
            {
                ID = Guid.NewGuid(),
                Name = "Суп"
            };

            var cat3 = new Category()
            {
                ID = Guid.NewGuid(),
                Name = "Японские супы",
                ParentCategory = cat1,
                Products = new Collection<Product>()
                {
                    product1
                }
            };

            cat1.ChildCategories = new List<Category>() { cat3 };

            var cat2 = new Category()
            {
                ID = Guid.NewGuid(),
                Name = "Второе блюдо",
                Products = new Collection<Product>()
                {
                    product2,
                    product3
                }
            };
            dc.Categories.Add(cat1);
            dc.Categories.Add(cat2);
            dc.Categories.Add(cat3);

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "customer" };
            var role3 = new IdentityRole { Name = "employee" };


            // добавляем роли в бд
            await roleStore.CreateAsync(role1);
            await roleStore.CreateAsync(role2);
            await roleStore.CreateAsync(role3);

            var organization = new Organization()
            {
                Id = Guid.NewGuid(),
                Name = "Роша и копыта",
                Points = new List<Entity.Point>()
                {
                    new Entity.Point() {Id = Guid.NewGuid(),Adress="Садовая"},
                    new Entity.Point() {Id = Guid.NewGuid(),Adress="Сенатска"}
                }
            };
            dc.Organizations.Add(organization);


            var appUser = new ApplicationUser() { UserName = "Admin@mail.ru", Email = "Admin@mail.ru" };
            var result = await userManager.CreateAsync(appUser, "Adminqwaszx123`");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(appUser, role1.Name);
            }

            var appCustomer = new ApplicationUser() { UserName = "Sneveld@mail.ru", Email = "Sneveld@mail.ru" };
            var result1 = await userManager.CreateAsync(appCustomer, "SneveldSneveld123`");
            appCustomer.Person = new Customer()
            {
                FirstName = "Иванов",
                MiddleName = "Иван",
                LastName = "Иванович",
                Organization = organization
            };
            if (result1.Succeeded)
            {
                await userManager.AddToRoleAsync(appCustomer, role2.Name);
            }

            var order = new Order()
            {
                ID = Guid.NewGuid(),
                Customer = appCustomer.Person as Customer,
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now,

                Items = new List<OrderItem>()
                {
                    new OrderItem {ID= Guid.NewGuid(),Product= product1,Mass=10,Count=1},
                    new OrderItem {ID= Guid.NewGuid(),Product= product2,Mass=4,Count=1}
                },
                OrderInfo = new OrderInfo()
                {
                    Apartment = "5",
                    City = "Калининград",
                    Floor = "4",
                    HouseNumber = "3",
                    ID = Guid.NewGuid(),
                    Number = "895683938473",
                    Street = "Артиллерийская"
                }
            };
            var order2 = new Order()
            {
                ID = Guid.NewGuid(),
                Customer = appCustomer.Person as Customer,
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now,

                Items = new List<OrderItem>()
                {
                    new OrderItem {ID= Guid.NewGuid(),Product= product1,Mass=10,Count=1},
                    new OrderItem {ID= Guid.NewGuid(),Product= product2,Mass=4,Count=1}
                },
                OrderInfo = new OrderInfo()
                {
                    Apartment = "15",
                    City = "Калининград",
                    Floor = "2",
                    HouseNumber = "1б",
                    ID = Guid.NewGuid(),
                    Number = "89094736398",
                    Street = "Батальная"
                }
            };
            dc.Orders.Add(order);
            dc.Orders.Add(order2);

            var orderPoint = new OrderPoint()
            {
                ID = Guid.NewGuid(),
                FullAdress = "ул. Карла Маркса, 18",
                Name = "Британика на Леонова",
                Latitude = "54.728667",
                Longitude = "20.481351",
                Index = 1
            };
            var orderPoint2 = new OrderPoint()
            {
                ID = Guid.NewGuid(),
                FullAdress = "ТРК Эпицентр, ул. Горького, 2",
                Name = "Британника, Английский Паб",
                Latitude = "54.721719",
                Longitude = "20.508268",
                Index = 2
            };

            dc.OrderPoints.Add(orderPoint);
            dc.OrderPoints.Add(orderPoint2);


            var lp1 = new LandingPageImage()
            {
                Id = Guid.NewGuid(),
                Index = 1,
                Image = ImageToByte("TestFiles/1.jpg"),
                Name = "Image1",
                Description = "Image1"
            };
            dc.LandingPageImages.Add(lp1);

            var lp2 = new LandingPageImage()
            {
                Id = Guid.NewGuid(),
                Index = 2,
                Image = ImageToByte("TestFiles/2.jpg"),
                Name = "Image2",
                Description = "Image2"
            };
            dc.LandingPageImages.Add(lp2);

            dc.SaveChanges();
        
        }
        private byte[] ImageToByte(string filePath)
        {
            Image img = Image.FromFile(filePath);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }

    }

}
