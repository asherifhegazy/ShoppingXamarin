using eShopApp.Models;
using eShopApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels
{
    public class ProductDetailsPageViewModel : BaseViewModel
    {
        public Product Product { get; set; }

        private readonly IProductService _productService;
        private readonly IPageService _pageService;

        string stepper;

        public string Stepper
        {
            get => stepper;

            set
            {
                if (stepper != value)
                {
                    SetValue(ref stepper, value);
                    OnPropertyChanged(nameof(Stepper));
                }
            }
        }

        public ICommand AddToCartCommand { get; set; }

        public ProductDetailsPageViewModel(int productId, IProductService productService, IPageService pageService)
        {
            _productService = productService;
            _pageService = pageService;

            Product = _productService.GetProductById(productId);

            AddToCartCommand = new Command(OnAddToCartCommand);
        }

        private void OnAddToCartCommand()
        {
            _pageService.DisplayAlert("Add To Cart",$"{Product.Name}","OK","CANCEL");
        }
    }
}
