using eShopApp.Services;
using eShopApp.Views;
using eShopApp.Views.Modals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels.Shared
{
    public class NavbarViewModel : BaseViewModel
    {
        string username;

        public string Username
        {
            get => username;

            set
            {
                if (username != value)
                {
                    SetValue(ref username, value);
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        int numberOfCartItems;

        public int NumberOfCartItems
        {
            get => numberOfCartItems;

            set
            {
                if (numberOfCartItems != value)
                {
                    SetValue(ref numberOfCartItems, value);
                    OnPropertyChanged(nameof(NumberOfCartItems));
                }
            }
        }

        public ICommand DotsCommand { get; set; }

        public ICommand CartCommand { get; set; }

        public bool IsFilterEnabled { get; set; }

        private readonly ICartSerivce _cartService;
        private readonly IUserService _userService;
        private readonly IPageService _pageService;

        public NavbarViewModel(ICartSerivce cartSerivce, IUserService userService, IPageService pageService)
        {
            Username = Global.UserName.ToString();

            _cartService = cartSerivce;
            _userService = userService;
            _pageService = pageService;

            OnAppearing();

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
                    await _pageService.PushModalAsync(new FilterModalPage());
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

        private async void OnAppearing()
        {
            var userId = await _userService.GetUserIdByUsername(username);

            NumberOfCartItems = await _cartService.GetNumberOfCartItems(userId);
        }
    }
}
