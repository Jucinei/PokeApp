using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApp.Models.Response
{
    public class TypeResponse
    {
        public List<TypePokemon> Results { get; set; }
    }

    public class TypePokemon
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

}
