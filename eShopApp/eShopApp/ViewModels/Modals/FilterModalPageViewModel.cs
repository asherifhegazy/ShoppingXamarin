using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels.Modals
{
    public class FilterModalPageViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

        int minPrice = 50;

        public int MinPrice
        {
            get => minPrice;

            set
            {
                if (minPrice != value)
                {
                    SetValue(ref minPrice, value);
                    OnPropertyChanged(nameof(minPrice));
                }
            }
        }

        int maxPrice = 650;

        public int MaxPrice
        {
            get => maxPrice;

            set
            {
                if (maxPrice != value)
                {
                    SetValue(ref maxPrice, value);
                    OnPropertyChanged(nameof(maxPrice));
                }
            }
        }

        public ICommand ApplyFilterCommand { get; set; }
        public ICommand ClearFilterCommand { get; set; }

        public FilterModalPageViewModel(IPageService pageService)
        {
            _pageService = pageService;

            ApplyFilterCommand = new Command(OnApplyFilterCommand);
            ClearFilterCommand = new Command(OnClearFilterCommand);
        }

        private async void OnApplyFilterCommand()
        {
            Global.FilterMinPrice = $"{minPrice}";
            Global.FilterMaxPrice = $"{maxPrice}";

            await _pageService.PopModalAsync();
        }

        private async void OnClearFilterCommand()
        {
            Global.FilterMinPrice = null;
            Global.FilterMaxPrice = null;

            await _pageService.PopModalAsync();
        }
    }
}
