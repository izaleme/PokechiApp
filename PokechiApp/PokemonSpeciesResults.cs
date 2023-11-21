using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokechiApp;

namespace PokechiApp
{
    public class PokemonSpeciesResults
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonSpeciesResults> Results { get; set; }
        public string Name { get; set; }
    }
}
