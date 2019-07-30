using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eShopApp.Services
{
    public interface ICartSerivce
    {
        ObservableCollection<CartItem> GetCartItems(int uid);

        void AddCartItem(CartItem cartItem);

        int GetNumberOfCartItems(int uid);

        void RemoveItemFromCart(CartItem cartItem);

        void SubmitOrder(int uid);
    }
}
