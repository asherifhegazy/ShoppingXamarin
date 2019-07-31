using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopApp.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetProductsOrderedByPrice();

        Task<IList<Product>> GetProductsOrderedByPriceAndFiltered(int minPrice, int maxPrice);

        Task<Product> GetProductById(int id);
    }
}
