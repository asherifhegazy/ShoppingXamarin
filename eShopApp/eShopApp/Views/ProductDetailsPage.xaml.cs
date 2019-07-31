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
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPageViewModel ProductDetailsPageViewModel { get; set; }

        private int _productId;
        public ProductDetailsPage(int id)
        {
            InitializeComponent();

            _productId = id;

            ProductDetailsPageViewModel = new ProductDetailsPageViewModel(new ProductService(), new CartService(), new UserService(), new PageService());

            BindingContext = ProductDetailsPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ProductDetailsPageViewModel.OnAppearing(_productId);
        }
    }

}