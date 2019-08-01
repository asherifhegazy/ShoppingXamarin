using System.Linq;
using eShopApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eShopApp.Services
{
    public class ProductService : BaseService ,IProductService
    {
        const string url = "Products";

        public async Task<Product> GetProductById(int id)
        {
            var response = await Client.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(message);
                if (product.Images.Count() == 0)
                    product.Images.Add(product.ImagePosterUrl);

                return product;
            }

            return new Product();
        }
        public async Task<IList<Product>> GetProductsOrderedByPrice()
        {
            var response = await Client.GetAsync($"{url}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IList<Product>>(message);
                return products.OrderBy(p => p.Price).ToList();
            }

            return new List<Product>();
        }

        public async Task<IList<Product>> GetProductsOrderedByPriceAndFiltered(int minPrice, int maxPrice)
        {
            var response = await Client.GetAsync($"{url}/filter/{minPrice}/{maxPrice}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IList<Product>>(message);
                return products.OrderBy(p => p.Price).ToList();
            }

            return new List<Product>();
        }
    }

        
}

