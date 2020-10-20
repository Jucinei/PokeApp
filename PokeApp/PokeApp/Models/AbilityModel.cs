using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApp.Models
{
    public class AbilityModel
    {
        public AbilityDetailsModel Ability { get; set; }
    }

    public class AbilityDetailsModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
