using System.Globalization;
using System.Collections.Generic;

namespace PokechiApp.Models
{
    public class PokemonDetailsResult
    {
        private string strPokeName = string.Empty;

        public List<AbilityDetail> Abilities { get; set; }
        public string Name
        {
            get => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strPokeName.ToLower());
            set => strPokeName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }
        public int Order { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    public class AbilityDetail
    {
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
