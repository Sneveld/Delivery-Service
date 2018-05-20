using Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SheepCrab.Delivery_Service.ClientModule.Extensions;
using SheepCrab.DeliveryService.Dto.Products;
using SheepCrab.DeliveryService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheepCrab.Delivery_Service.ClientModule.Controllers
{
    public class MainMenuController : Controller
    {
        public MainMenuController(
            IMainMenuService mainMenuService, 
            IOrderService orderService,
            IProductsService productsService)
        {
            _mainMenuService = mainMenuService;
            _orderService = orderService;
            _productsService = productsService;
        }

        private readonly IMainMenuService _mainMenuService;
        private readonly IOrderService _orderService;
        private readonly IProductsService _productsService;
        
        [HttpGet]
        public IEnumerable<CategoryDto> GetSiteMenu()
        {
            var menu = _mainMenuService.GetAllCategories();
            return menu;            
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetAllProducts()
        {            
            return _mainMenuService.GetAllProducts();
        }

        [HttpGet]
        public IEnumerable<ProductDto> UpDateProducts(Guid param)
        {
            if (param != Guid.Empty)
            {
                return _productsService.GetProductsByCategory(param);
            }
            return new List<ProductDto>();
        }

        [HttpGet]
        public IEnumerable<ProductDto> Find(string findname)
        {
            if (findname != string.Empty)
            {
                return _productsService.GetProductsByName(findname);
            }
            return new List<ProductDto>();
        }

        [HttpPost]
        public void AddProductToCard([FromBody]AddProductsDto addProductsDto)
        {
            ProductDto product = _mainMenuService.FindProduct(new Guid(addProductsDto.ProductId));
            if (product != null)
            {
                var order = GetOrder();
                order.AddProduct(product, addProductsDto.Count);
                HttpContext.Session.SetObject<OrderDto>("Order", order);
            }          
        }

        private OrderDto GetOrder()
        {
            OrderDto order = HttpContext.Session.GetObject<OrderDto>("Order"); 
            if (order == null)
            {
                order = _orderService.GetNewOrder();
                HttpContext.Session.SetObject<OrderDto>("Order", order);
            }
            return order;
        }

    }

    public class AddProductsDto
    {
        public string ProductId { get; set; }
        public int Count { get; set; }
    }

}
