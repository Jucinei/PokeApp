using PokeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PokeApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            collectionPokemons.SelectedItem = null;
            collectionTypes.SelectedItem = null;
        }
    }
}
