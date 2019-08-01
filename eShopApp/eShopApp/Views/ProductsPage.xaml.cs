using eShopApp.Services;
using eShopApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ProductsPageViewModel ProductsPageViewModel { get; set; }
        public ProductsPage()
        {
            InitializeComponent();

            ProductsPageViewModel = new ProductsPageViewModel(new ProductService(),new PageService());

            BindingContext = ProductsPageViewModel;

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // fire OnItemSelectedCommand from view and send the selected item as a paramter
            ProductsPageViewModel.OnItemSelectedCommand.Execute(e.Item);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ProductsPageViewModel.OnAppearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;
        }
    }
}