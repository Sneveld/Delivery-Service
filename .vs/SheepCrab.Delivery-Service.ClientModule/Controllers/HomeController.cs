using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SheepCrab.Delivery_Service.ClientModule.Models;
using SheepCrab.Delivery_Service.ClientModule.Services;
using SheepCrab.DeliveryService.Dto.ViewModels;
using SheepCrab.DeliveryService.Model.Interfaces;

namespace SheepCrab.Delivery_Service.ClientModule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILandingPageService _landingPageService;
        private readonly DbInit dbInit;

        public HomeController(ILandingPageService landingPageService, DbInit dbInit)
        {
            _landingPageService = landingPageService;
            this.dbInit = dbInit;
        }
        public IActionResult Index()
        {
            return View();
        }  

        [HttpGet]
        public IEnumerable<LandingPageImageViewModel> GetLandingPageImages()
        {
            return _landingPageService.GetAllLandingPageImages();
        }

        //for test
        public async Task InitDbAsync()
        {
            await dbInit.InitDbAsync();
        }
        
    }
}
