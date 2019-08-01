﻿using eShopApp.Services;
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
        public ProductDetailsPage(int id)
        {
            InitializeComponent();

            ProductDetailsPageViewModel = new ProductDetailsPageViewModel(id, new ProductService(), new CartService(), new UserService(), new PageService());

            BindingContext = ProductDetailsPageViewModel;

            //carousel.ItemSource = new Color[] {
            //    Color.Red,
            //    Color.Blue,
            //    Color.Green,
            //    Color.Purple,
            //    Color.Yellow
            //};

            //carousel.ItemTemlate = new DataTemplate(typeof(CarouselViewCell));
        }
    }

    //class CarouselViewCell : ViewCell
    //{
    //    public CarouselViewCell()
    //    {
    //        View = new BoxView();
    //    }

    //    protected override void OnBindingContextChanged()
    //    {
    //        base.OnBindingContextChanged();

    //        View.BackgroundColor = (Color)BindingContext;
    //    }
    //}
}