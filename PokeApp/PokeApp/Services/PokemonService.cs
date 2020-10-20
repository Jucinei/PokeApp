using Flurl;
using Flurl.Http;
using Microsoft.AppCenter.Crashes;
using PokeApp.Helpers;
using PokeApp.Interfaces;
using PokeApp.Models;
using PokeApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApp.Services
{
    public class PokemonService : IPokemonService
    {

        public async Task<PokemonModel> GetPokemon(string url)
        {
            try
            {
                var pokemon = await Url.Combine(url)
                    .GetJsonAsync<PokemonModel>();

                return pokemon ?? new PokemonModel();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "Erro", "Falha ao obter detalhes do pokemon" },
                    { "Onde", "Método 'GetPokemon' na classe PokemonService" },
                    { "Url", $"{url}" }
                });

                return new PokemonModel();
            }
        }

        public async Task<PokemonResponse> GetPokemonsByType(string url)
        {
            try
            {
                var types = await Url.Combine(url)
                    .GetJsonAsync<PokemonResponse>();

                return types ?? new PokemonResponse();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "Erro", "Falha ao obter pokemons de determinado tipo" },
                    { "Onde", "Método 'GetPokemonsByType' na classe PokemonService" },
                    { "Url", $"{url}" }
                });

                return new PokemonResponse();
            }
        }

        public async Task<TypeResponse> GetTypes()
        {
            try
            {
                var types = await Url.Combine(Constants.BASE_URL + "type")
                    .GetJsonAsync<TypeResponse>();

                return types ?? new TypeResponse();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    { "Erro", "Falha ao obter os tipos de pokemons disponíveis" },
                    { "Onde", "Método 'GetTypes' na classe PokemonService" },
                    { "Url", $"{Constants.BASE_URL + "type"}" }
                });

                return new TypeResponse();
            }
        }
    }
}
