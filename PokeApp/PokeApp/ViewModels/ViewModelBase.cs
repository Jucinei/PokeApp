using PokeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public INavigationService NavigationService { get; set; }
        public IPokemonService PokemonService { get; set; }

        public ViewModelBase()
        {
            NavigationService = DependencyService.Get<INavigationService>();
            PokemonService = DependencyService.Get<IPokemonService>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
