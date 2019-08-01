using eShopApp.Models;
using eShopApp.Renderers;
using eShopApp.Services;
using eShopApp.ViewModels.Shared;
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

        public ICommand SubmitCommand { get; set; }

        public CartPageViewModel(ICartSerivce cartSerivce, IUserService userService, IOrderService orderService, IPageService pageService)
        {
            _cartService = cartSerivce;
            _userService = userService;
            _orderService = orderService;
            _pageService = pageService;

            MessagingCenter.Subscribe<CartItemViewViewModel, CartItem>(this, "CartItemsChanged", OnNumerOfCartItemsChanged);


            SubmitCommand = new Command(OnSubmitCommand);
        }

        private void OnNumerOfCartItemsChanged(CartItemViewViewModel source, CartItem newValue)
        {
            CartItems.Remove(newValue);
        }

        private async void OnSubmitCommand()
        {
            IsLoading = true;

            var userId = await _userService.GetUserIdByUsername(Global.UserName.ToString());

            var isSubmitted = await _orderService.SubmitOrder(userId);

            if (isSubmitted)
            {
                //await _pageService.DisplayAlert("Success", "Order Was Submitted Successfully", "OK", "Cancel");
                DependencyService.Get<IToast>().ShowShortMessage("Order Submitted successfully");
                await _pageService.PushAsync(new ProductsPage());
            }
            else
            {
                DependencyService.Get<IToast>().ShowShortMessage("Something Went Wrong");
                //await _pageService.DisplayAlert("Failed", "Something Went Wrong", "OK", "Cancel");
            }

            IsLoading = false;
        }

        public async void OnAppearing()
        {
            CartItems = new ObservableCollection<CartItem>();

            IsLoading = true;

            var userId = await _userService.GetUserIdByUsername(Global.UserName.ToString());

            CartItems = await _cartService.GetCartItems(userId);

            IsLoading = false;

            if (CartItems.Count == 0)
                DependencyService.Get<IToast>().ShowShortMessage("Cart is Empty");
                //await _pageService.DisplayAlert("Warning", "Cart is Empty", "OK", "Cancel");
            //IsSubmitEnabled = false;
        }
    }
}
