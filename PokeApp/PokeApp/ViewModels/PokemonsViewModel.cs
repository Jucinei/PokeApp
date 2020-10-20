using Acr.UserDialogs;
using Plugin.Share;
using PokeApp.Models;
using PokeApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public class PokemonsViewModel : ViewModelBase
    {

        #region [PROPS]
        public List<AbilityDetailsModel> Abilities { get; set; }
        public string[] AbilitiesArray { get; set; }
        public string UrlImage { get; set; }
        public string Name { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }

        public Command BackButtonCommand { get; set; }
        public Command ShareCommand { get; set; }

        #endregion

        public PokemonsViewModel(string url)
        {
            Abilities = new List<AbilityDetailsModel>();

            BackButtonCommand = new Command(async () => await NavigationService.NavigateToBack());
            ShareCommand = new Command(ShareInfo);

            LoadData(url);
        }

        private async void LoadData(string url)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando");

                var pokemon = await PokemonService.GetPokemon(url);

                var abilities = new List<AbilityDetailsModel>();

                foreach (var item in pokemon.Abilities)
                {
                    abilities.Add(item.Ability);
                }

                Abilities = abilities;

                UrlImage = pokemon.Sprites.Front_Default ?? "";
                Name = pokemon.Name.ToUpper() ?? "";
                Weight = pokemon.Weight;
                Height = pokemon.Height;
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

        private void ShareInfo()
        {
            List<string> abilities = new List<string>();
            for (int i = 0; i < Abilities.Count; i++)
            {
                abilities.Add(Abilities.ElementAtOrDefault(i).Name);
            }

            var ShareMessage = new Plugin.Share.Abstractions.ShareMessage
            {
                Text = $"*{Name}* \n" +
                $"*Altura:* {Height} \n" +
                $"*Peso:* {Weight} \n" +
                $"*Habilidades:* {abilities.Aggregate((prev, str) => $"{prev}, {str}")}",
                Title = $"Pokemon - {Name}",
            };

            CrossShare.Current.Share(ShareMessage);
        }
    }
}
