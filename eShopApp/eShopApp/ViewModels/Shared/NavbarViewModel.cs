using eShopApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels.Shared
{
    public class NavbarViewModel : BaseViewModel
    {
        public string Username { get; set; }

        public ICommand DotsCommand { get; set; }

        public ICommand CartCommand { get; set; }

        public bool IsFilterEnabled { get; set; }

        private readonly IPageService _pageService;

        public NavbarViewModel(IPageService pageService)
        {
            Username = Global.UserName;

            _pageService = pageService;

            CartCommand = new Command(OnCartCommand);
            DotsCommand = new Command(OnDotsCommand);
        }

        private async void OnCartCommand()
        {
            await _pageService.PushAsync(new CartPage());
        }

        private async void OnDotsCommand()
        {
            string action = string.Empty;

            if (IsFilterEnabled)
                action = await _pageService.DisplayActionSheet(null, "Cancel", null, "Filter", "Sync", "Logout");
            else
                action = await _pageService.DisplayActionSheet(null, "Cancel", null, "Home", "Sync", "Logout");


            switch (action)
            {
                case "Home":
                    await _pageService.PushAsync(new ProductsPage());
                    break;

                case "Filter":
                    break;

                case "Sync":
                    break;

                case "Logout":
                    await _pageService.PopToRootAsync();
                    break;

                default:
                    break;
            }
        }
    }
}
