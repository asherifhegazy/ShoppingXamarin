using eShopApp.Services;
using eShopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPageViewModel CartPageViewModel { get; set; }
        public CartPage()
        {
            InitializeComponent();

            CartPageViewModel = new CartPageViewModel(new CartService(), new UserService(), new PageService());

            BindingContext = CartPageViewModel;
        }
    }
}