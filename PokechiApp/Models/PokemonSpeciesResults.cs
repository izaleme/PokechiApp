﻿using System.Collections.Generic;

namespace PokechiApp.Models
{
    public class PokemonSpeciesResults
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonResults> Results { get; set; }
    }
}
