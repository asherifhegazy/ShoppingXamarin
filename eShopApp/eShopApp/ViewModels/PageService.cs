using eShopApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eShopApp.ViewModels
{
    public class PageService : IPageService
    {
        //private readonly Page MainPage;

        //public PageService()
        //{
        //    MainPage = Application.Current.MainPage;
        //}

        public async Task PopToRootAsync()
        {

            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            var lastIndex = Application.Current.MainPage.Navigation.NavigationStack.Count() - 1;
            var lastPageType = Application.Current.MainPage.Navigation.NavigationStack[lastIndex].GetType();

            if (page.GetType() != lastPageType)
                await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModalAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(page);

        }

        public async Task PopModalAsync()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
