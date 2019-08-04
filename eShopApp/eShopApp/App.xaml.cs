using CommonServiceLocator;
using eShopApp.Services;
using eShopApp.ViewModels;
using eShopApp.Views;
using System;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            UnityContainer unityContainer = new UnityContainer();

            RegisterTypes(unityContainer);

            MainPage = new NavigationPage(new LoginPage());
        }

        private void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IUserService, UserService>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<ICartSerivce, CartService>();
            unityContainer.RegisterType<IOrderService, OrderService>();
            unityContainer.RegisterType<IPageService, PageService>();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
