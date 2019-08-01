using eShopApp.Models;
using eShopApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels
{
    public class CartPageViewModel
    {
        public ObservableCollection<CartItem> CartItems { get; set; }

        private readonly ICartSerivce _cartService;
        private readonly IUserService _userService;
        private readonly IPageService _pageService;

        public ICommand DeleteItemCommand { get; set; }

        public CartPageViewModel(ICartSerivce cartSerivce, IUserService userService, IPageService pageService)
        {
            _cartService = cartSerivce;
            _userService = userService;
            _pageService = pageService;

            var userId = _userService.GetUserIdByUsername(Global.UserName.ToString());

            CartItems = _cartService.GetCartItems(userId);

            DeleteItemCommand = new Command(OnDeleteItemCommand);
        }

        private void OnDeleteItemCommand()
        {
            _cartService.RemoveItemFromCart(null);
        }
    }
}
