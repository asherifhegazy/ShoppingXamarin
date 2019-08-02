using CommonServiceLocator;
using eShopApp.Models;
using eShopApp.Services;
using eShopApp.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopApp.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartItemView : ContentView
    {
        #region CartItem Bindable Property

        public static readonly BindableProperty CartItemProperty = BindableProperty.Create(
            nameof(CartItem), // Name of the public property
            typeof(CartItem),  // Type of Property
            typeof(CartItemView) // Type of the defining class
            , new CartItem(), // default value
            propertyChanged: OnCartItemPropertyChanged); // on changed method


        static void OnCartItemPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            CartItemView cartItemView = (CartItemView)bindable;
            cartItemView.CartItemViewViewModel.CartItem = (CartItem)newvalue;
        }


        public CartItem CartItem
        {
            get => (CartItem)GetValue(CartItemProperty);
            set
            {
                SetValue(CartItemProperty, value);
            }
        }

        #endregion

        public CartItemViewViewModel CartItemViewViewModel { get; set; }

        public CartItemView()
        {
            InitializeComponent();

            //CartItemViewViewModel = new CartItemViewViewModel(new CartService());
            CartItemViewViewModel = ServiceLocator.Current.GetInstance<CartItemViewViewModel>();

            BindingContext = CartItemViewViewModel;
        }
    }
}