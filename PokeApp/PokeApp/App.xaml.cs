using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using PokeApp.Helpers;
using PokeApp.Interfaces;
using PokeApp.Services;
using PokeApp.Views;
using Xamarin.Forms;

namespace PokeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IPokemonService, PokemonService>();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start($"ios={Constants.CHAVE_IOS};android={Constants.CHAVE_ANDROID};", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
