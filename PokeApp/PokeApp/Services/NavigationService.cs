using PokeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateTo(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NavigateToBack()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
