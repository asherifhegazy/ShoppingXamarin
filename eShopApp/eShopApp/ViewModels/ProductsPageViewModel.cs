using eShopApp.Models;
using eShopApp.Services;
using eShopApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels
{
    public class ProductsPageViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        private readonly IProductService _productService;
        private readonly IPageService _pageService;

        public ICommand OnItemSelectedCommand { get; set; }
        public ProductsPageViewModel(IProductService productService, IPageService pageService)
        {
            _productService = productService;
            _pageService = pageService;

            Products = _productService.GetProducts();

            OnItemSelectedCommand = new Command<object>(OnSelectedItem);
        }

        private async void OnSelectedItem(object obj)
        {
            // cast item selected from object to Item
            var product = obj as Product;

            await _pageService.PushAsync(new ProductDetailsPage(product.Id));
        }
    }
}
