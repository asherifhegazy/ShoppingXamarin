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
        public Product Product { get; set; }

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

        public ProductDetailsPageViewModel(int productId, IProductService productService, ICartSerivce cartSerivce, IUserService userService, IPageService pageService)
        {
            _productService = productService;
            _cartService = cartSerivce;
            _userService = userService;
            _pageService = pageService;

            Product = _productService.GetProductById(productId);

            AddToCartCommand = new Command(OnAddToCartCommand);
        }

        private async void OnAddToCartCommand()
        {
            var cartItem = new CartItem
            {
                UserId = await _userService.GetUserIdByUsername(Global.UserName.ToString()),
                ProductId = Product.Id,
                Product = Product,
                Quantity = stepper,
                CreatedDate = DateTime.Now
            };

            _cartService.AddCartItem(cartItem);

            //DependencyService.Get<IToast>().ShowShortMessage("Cart updated successfully");

            await _pageService.PushAsync(new ProductsPage());
        }
    }
}
