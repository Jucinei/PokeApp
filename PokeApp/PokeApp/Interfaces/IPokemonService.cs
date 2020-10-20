using PokeApp.Models;
using PokeApp.Models.Response;
using System.Threading.Tasks;

namespace PokeApp.Interfaces
{
    public interface IPokemonService
    {
        Task<TypeResponse> GetTypes();
        Task<PokemonResponse> GetPokemonsByType(string url);
        Task<PokemonModel> GetPokemon(string url);
    }
}
