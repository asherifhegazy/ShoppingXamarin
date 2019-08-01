using eShopApp.Models;
using eShopApp.Renderers;
using eShopApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels.Shared
{
    public class CartItemViewViewModel : BaseViewModel
    {
        CartItem cartItem;

        public CartItem CartItem
        {
            get => cartItem;

            set
            {
                if (cartItem != value)
                {
                    SetValue(ref cartItem, value);
                    OnPropertyChanged(nameof(CartItem));
                }
            }
        }

        private readonly ICartSerivce _cartService;

        public ICommand DeleteItemCommand { get; set; }


        public CartItemViewViewModel(ICartSerivce cartSerivce)
        {
            _cartService = cartSerivce;

            var product = new Product();
            CartItem = new CartItem
            {
                Product = product
            };

            DeleteItemCommand = new Command(OnDeleteItemCommand);
        }

        private async void OnDeleteItemCommand()
        {

            var isDeleted = await _cartService.RemoveItemFromCart(CartItem);

            if (isDeleted)
                MessagingCenter.Send(this, "CartItemsChanged", CartItem);
            //DependencyService.Get<IToast>().ShowShortMessage($"Item Deleted Successfully");
            else
                DependencyService.Get<IToast>().ShowShortMessage($"Couldn't Delete Item");
        }
    }
}
