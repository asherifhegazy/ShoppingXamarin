using CommonServiceLocator;
using eShopApp.Services;
using eShopApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPageViewModel LoginPageViewModel { get; set; }
        public LoginPage()
        {
            InitializeComponent();

            //LoginPageViewModel = new LoginPageViewModel(new UserService(), new PageService());
            LoginPageViewModel = ServiceLocator.Current.GetInstance<LoginPageViewModel>();

            BindingContext = LoginPageViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoginPageViewModel.Username = "ahmed";
        }

    }
}