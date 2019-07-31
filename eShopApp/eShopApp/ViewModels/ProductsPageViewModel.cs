using eShopApp.Models;
using eShopApp.Services;
using eShopApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace eShopApp.ViewModels
{
    public class ProductsPageViewModel : BaseViewModel
    {
        IList<Product> products;
        public IList<Product> Products
        {
            get => products;
            set
            {
                if (products != value)
                {
                    SetValue(ref products, value);
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        private readonly IProductService _productService;
        private readonly IPageService _pageService;

        public ICommand OnItemSelectedCommand { get; set; }
        public ProductsPageViewModel(IProductService productService, IPageService pageService)
        {
            _productService = productService;
            _pageService = pageService;

            OnItemSelectedCommand = new Command<object>(OnSelectedItem);
        }

        private async void OnSelectedItem(object obj)
        {
            // cast item selected from object to Item
            var product = obj as Product;

            await _pageService.PushAsync(new ProductDetailsPage(product.Id));
        }

        public void OnAppearing()
        {
            var filterMinPrice = Global.FilterMinPrice;
            var filterMaxPrice = Global.FilterMaxPrice;

            if (filterMinPrice == null)
                Products = _productService.GetProductsOrderedByPrice();
            else
            {
                int.TryParse(filterMinPrice.ToString(), out int minPrice);
                int.TryParse(filterMaxPrice.ToString(), out int maxPrice);
                Products = _productService.GetProductsOrderedByPriceAndFiltered(minPrice, maxPrice);
            }
        }
    }
}
