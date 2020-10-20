using Acr.UserDialogs;
using PokeApp.Models.Response;
using PokeApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private PokemonSlot _pokemonSelected;
        public PokemonSlot PokemonSelected
        {
            get => _pokemonSelected;
            set
            {
                if (value != null)
                {
                    _pokemonSelected = value;
                    DetailPokemons(value.Pokemon.Url);
                }
            }
        }

        private TypePokemon _type;
        public TypePokemon Type
        {
            get => _type;
            set
            {
                if(value != null)
                {
                    _type = value;
                    LoadPokemons(value.Url);
                }
            }
        }

        public List<TypePokemon> Types { get; set; }
        public List<PokemonSlot> Pokemons { get; set; }

        public string TypePokemons { get; set; }

        public MainViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando");

                var types = await PokemonService.GetTypes();

                Pokemons = new List<PokemonSlot>();

                Types = types != null ? types.Results : new List<TypePokemon>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void LoadPokemons(string url)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando");

                var pokemons = await PokemonService.GetPokemonsByType(url);

                TypePokemons = pokemons.Name.ToUpper();

                Pokemons = pokemons != null ? pokemons.Pokemon : new List<PokemonSlot>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void DetailPokemons(string url)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando");

                await NavigationService.NavigateTo(new PokemonsPage(url));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}
