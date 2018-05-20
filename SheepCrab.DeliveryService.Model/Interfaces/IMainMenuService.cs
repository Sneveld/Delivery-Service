using SheepCrab.DeliveryService.Dto.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.Model.Interfaces
{
    public interface IMainMenuService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        ProductDto FindProduct(Guid productId);
        ICollection<ProductDto> GetAllProducts();
    }
}
