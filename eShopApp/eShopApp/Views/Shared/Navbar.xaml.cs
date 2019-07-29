﻿using eShopApp.ViewModels;
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

        public static readonly BindableProperty IsFilterEnabledProperty = BindableProperty.Create(


        static void OnIsFilterEnabledChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            navbar.NavbarViewModel.IsFilterEnabled = (bool)newvalue;
        }
        {

        #endregion

        public NavbarViewModel NavbarViewModel { get; set; }
        public Navbar()
        {
            InitializeComponent();

            NavbarViewModel = new NavbarViewModel(new PageService());

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