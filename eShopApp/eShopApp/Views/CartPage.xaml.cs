using CommonServiceLocator;
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

            //CartPageViewModel = new CartPageViewModel(new CartService(), new UserService(), new OrderService(), new PageService());
            CartPageViewModel = ServiceLocator.Current.GetInstance<CartPageViewModel>();

            BindingContext = CartPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CartPageViewModel.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;
        }
    }
}