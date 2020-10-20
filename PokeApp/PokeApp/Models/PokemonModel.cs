using System.Collections.Generic;

namespace PokeApp.Models
{
    public class PokemonModel
    {
        public long Height { get; set; }
        public long Weight { get; set; }
        public string Name { get; set; }
        public List<AbilityModel> Abilities { get; set; }
        public SpriteModel Sprites { get; set; }
    }
}
