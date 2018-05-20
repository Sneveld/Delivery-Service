using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using DataContext;
using Entity;
using SheepCrab.DeliveryService.Model.Interfaces;
using SheepCrab.DeliveryService.Dto.Products;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using AutoMapper;

namespace SheepCrab.DeliveryService.Model
{
    public class MainMenuService : IMainMenuService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public MainMenuService(
            ICategoryRepository categoryRepository,
            IProductsRepository productsRepository,
            IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _mapper.Map<List<CategoryDto>>(_categoryRepository.GetAll());
        }
        public ProductDto FindProduct(Guid productId)
        {
            return _mapper.Map<ProductDto>(_productsRepository.FindProduct(productId));
        }

        public ICollection<ProductDto> GetAllProducts()
        {
            return _mapper.Map<List<ProductDto>>(_productsRepository.GetAll());
        }

        
    }
}