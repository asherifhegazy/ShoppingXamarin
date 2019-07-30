using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eShopApp.Models;
using System.Linq;

namespace eShopApp.Services
{
    public class CartService : ICartSerivce
    {
        ObservableCollection<CartItem> CartItems { get; set; } = new ObservableCollection<CartItem>();

        public void AddCartItem(CartItem cartItem)
        {
            CartItems.Add(cartItem);
        }

        public ObservableCollection<CartItem> GetCartItems(int uid)
        {
            return CartItems;
        }

        public int GetNumberOfCartItems(int uid)
        {
            return CartItems.Where(ci => ci.UserId == uid).Sum(ci=>ci.Quantity);
        }

        public void RemoveItemFromCart(CartItem cartItem)
        {
            CartItems.Remove(cartItem);
        }

        public void SubmitOrder(int uid)
        {
            throw new NotImplementedException();
        }
    }
}
