using eShopApp.ViewModels;
using eShopApp.ViewModels.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopApp.Views.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterModalPage : ContentPage
    {
        public FilterModalPageViewModel FilterModalPageViewModel { get; set; }
        public FilterModalPage()
        {
            InitializeComponent();

            FilterModalPageViewModel = new FilterModalPageViewModel(new PageService());

            BindingContext = FilterModalPageViewModel;
        }
    }
}