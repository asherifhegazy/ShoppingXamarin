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
    public class CartPageViewModel : BaseViewModel
    {
        ObservableCollection<CartItem> cartItems;

        public ObservableCollection<CartItem> CartItems
        {
            get => cartItems;

            set
            {
                if (cartItems != value)
                {
                    SetValue(ref cartItems, value);
                    OnPropertyChanged(nameof(CartItems));
                }
            }
        }

        private readonly ICartSerivce _cartService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IPageService _pageService;

        public ICommand DeleteItemCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public CartPageViewModel(ICartSerivce cartSerivce, IUserService userService, IOrderService orderService, IPageService pageService)
        {
            _cartService = cartSerivce;
            _userService = userService;
            _orderService = orderService;
            _pageService = pageService;

            DeleteItemCommand = new Command(OnDeleteItemCommand);
            SubmitCommand = new Command(OnSubmitCommand);
        }

        private void OnDeleteItemCommand()
        {
            _cartService.RemoveItemFromCart(null);
        }

        private async void OnSubmitCommand()
        {
            var userId = await _userService.GetUserIdByUsername(Global.UserName.ToString());

            var isSubmitted = await _orderService.SubmitOrder(userId);

            if (isSubmitted)
            {
                await _pageService.DisplayAlert("Success", "Order Submitted Successfully", "OK", "Cancel");
                //DependencyService.Get<IToast>().ShowShortMessage("Order Submitted successfully");
                await _pageService.PushAsync(new ProductsPage());
            }
            else
            {
                await _pageService.DisplayAlert("Failed", "Something Went Wrong", "OK", "Cancel");
            }
        }

        public async void OnAppearing()
        {
            var userId = await _userService.GetUserIdByUsername(Global.UserName.ToString());

            CartItems = await _cartService.GetCartItems(userId);
        }
    }
}
