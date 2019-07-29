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
            await _pageService.DisplayAlert("cart","cart","ok","cancel");
            //await _pageService.PushAsync(null);
        }

        private async void OnDotsCommand()
        {
            string action = await _pageService.DisplayActionSheet(null, "Cancel", null, "Home", "Filter", "Sync", "Logout");

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
