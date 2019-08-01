using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopApp.Services
{
    public interface IProductService
    {
        IList<Product> GetProductsOrderedByPrice();

        IList<Product> GetProductsOrderedByPriceAndFiltered(int minPrice, int maxPrice);

        Product GetProductById(int id);
    }
}
