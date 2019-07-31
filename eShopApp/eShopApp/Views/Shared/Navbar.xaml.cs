using eShopApp.Services;
using eShopApp.ViewModels;
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
    public partial class Navbar : ContentView
    {

        #region IsFilterEnabled Bindable Property

        public static readonly BindableProperty IsFilterEnabledProperty = BindableProperty.Create(            nameof(IsFilterEnabled), // Name of the public property            typeof(bool),  // Type of Property            typeof(Navbar) // Type of the defining class            , false, // default value            propertyChanged: OnIsFilterEnabledChanged); // on changed method


        static void OnIsFilterEnabledChanged(BindableObject bindable, object oldvalue, object newvalue)
        {            Navbar navbar = (Navbar)bindable;
            navbar.NavbarViewModel.IsFilterEnabled = (bool)newvalue;
        }        public bool IsFilterEnabled
        {            get => (bool)GetValue(IsFilterEnabledProperty);            set            {                SetValue(IsFilterEnabledProperty, value);            }        }

        #endregion

        public NavbarViewModel NavbarViewModel { get; set; }
        public Navbar()
        {
            InitializeComponent();

            NavbarViewModel = new NavbarViewModel(new CartService(), new UserService(), new PageService());

            BindingContext = NavbarViewModel;
        }

        private void DotsIconTabbed(object sender, EventArgs e)
        {
            NavbarViewModel.DotsCommand.Execute(null);
        }

        private void CartIconTabbed(object sender, EventArgs e)
        {
            NavbarViewModel.CartCommand.Execute(null);
        }

    }
}