using eShopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eShopApp.Services
{
    public interface ICartSerivce
    {
        Task<ObservableCollection<CartItem>> GetCartItems(int uid);

        Task<bool> AddCartItem(CartItem cartItem);

        Task<int> GetNumberOfCartItems(int uid);

        Task<bool> RemoveItemFromCart(CartItem cartItem);

    }
}
