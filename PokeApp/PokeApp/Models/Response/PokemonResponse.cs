using System.Collections.Generic;

namespace PokeApp.Models.Response
{
    public class PokemonResponse
    {
        public string Name { get; set; }
        public List<PokemonSlot> Pokemon { get; set; }
    }

    public class PokemonSlot
    {
        public Pokemon Pokemon { get; set; }
        public long Slot { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
