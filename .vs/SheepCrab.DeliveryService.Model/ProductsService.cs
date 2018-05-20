using AutoMapper;
using Entity;
using SheepCrab.DeliveryService.DataAccess.Interfaces;
using SheepCrab.DeliveryService.Dto.Products;
using SheepCrab.DeliveryService.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheepCrab.DeliveryService.Model
{
    public class ProductsService: IProductsService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsService(
            ICategoryRepository categoryRepository,
            IProductsRepository productsRepository,
            IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public List<ProductDto> GetProductsByCategory(Guid categoryGuid)
        {
            var childsCategories = GetAllChildsCategories(_categoryRepository.GetAll(), categoryGuid);
            var products = _productsRepository.GetAll().Where(c => c.Category != null && childsCategories.Contains(c.Category.ID)).ToList();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        private IEnumerable<Guid> GetAllChildsCategories(IEnumerable<Category> categories, Guid parentCategoryId)
        {
            var childsCategoriesIds = new List<Guid> { parentCategoryId };

            var childsCategories = categories.Where(c => c.ParentCategoryId == parentCategoryId).ToList();
            childsCategoriesIds.AddRange(childsCategories.Select(c => c.ID));

            while (childsCategories.Any())
            {
                foreach (var childsCategory in childsCategories.ToList())
                {
                    childsCategories.AddRange(categories.Where(c => c.ParentCategoryId == childsCategory.ID));
                    childsCategories.Remove(childsCategory);
                }
                childsCategoriesIds.AddRange(childsCategories.Select(c => c.ID));
            }
            return childsCategoriesIds;
        }

        public List<ProductDto> GetProductsByName(string name)
        {
            var products = _productsRepository.GetAll();
            products = products.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }
    }
}
