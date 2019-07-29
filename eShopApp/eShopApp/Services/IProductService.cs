using eShopApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace eShopApp.Services
{
    public interface IProductService
    {
        ObservableCollection<Product> GetProducts();

        Product GetProductById(int id);
    }
}
