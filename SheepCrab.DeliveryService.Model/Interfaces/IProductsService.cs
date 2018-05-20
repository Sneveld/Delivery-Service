using SheepCrab.DeliveryService.Dto.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.Model.Interfaces
{
    public interface IProductsService
    {
        List<ProductDto> GetProductsByCategory(Guid categoryGuid);        
        List<ProductDto> GetProductsByName(string name);
    }
}
