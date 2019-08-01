using eShopApp.Models;
using eShopApp.Renderers;
using eShopApp.Services;
using eShopApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels
{
    public class ProductDetailsPageViewModel : BaseViewModel
    {
        Product product;

        public Product Product
        {
            get => product;

            set
            {
                if (product != value)
                {
                    SetValue(ref product, value);
                    OnPropertyChanged(nameof(Product));
                }
            }
        }

        private readonly IProductService _productService;
        private readonly ICartSerivce _cartService;
        private readonly IUserService _userService;
        private readonly IPageService _pageService;

        int stepper = 1;

        public int Stepper
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

        public ProductDetailsPageViewModel(IProductService productService, ICartSerivce cartSerivce, IUserService userService, IPageService pageService)
        {
            _productService = productService;
            _cartService = cartSerivce;
            _userService = userService;
            _pageService = pageService;

            AddToCartCommand = new Command(OnAddToCartCommand);
        }

        private async void OnAddToCartCommand()
        {
            IsLoading = true;

            var cartItem = new CartItem
            {
                UserId = await _userService.GetUserIdByUsername(Global.UserName.ToString()),
                ProductId = Product.Id,
                Product = Product,
                Quantity = stepper,
                CreatedDate = DateTime.Now
            };

            var isAdded = await _cartService.AddCartItem(cartItem);

            IsLoading = false;

            if (isAdded)
            {
                DependencyService.Get<IToast>().ShowShortMessage("Cart updated successfully");
                await _pageService.PushAsync(new ProductsPage());
            }
            else
            {
                DependencyService.Get<IToast>().ShowShortMessage("Something Went Wrong");
            }
        }

        public async void OnAppearing(int productId)
        {
            IsLoading = true;

            Product = await _productService.GetProductById(productId);

            IsLoading = false;
        }
    }
}
