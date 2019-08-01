using eShopApp.Renderers;
using eShopApp.Services;
using eShopApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eShopApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
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

        private readonly IUserService _userService;
        private readonly IPageService _pageService;

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel(IUserService userService, IPageService pageService)
        {
            _userService = userService;

            _pageService = pageService;

            LoginCommand = new Command(OnLoginCommand);
        }

        private async void OnLoginCommand()
        {
            IsLoading = true;

            var result = await _userService.IsUserExists(Username);

            IsLoading = false;

            if (result)
            {
                Global.UserName = Username;
                await _pageService.PushAsync(new ProductsPage());
            }
            else
                DependencyService.Get<IToast>().ShowShortMessage("Username Isn't correct");
        }

    }
}
