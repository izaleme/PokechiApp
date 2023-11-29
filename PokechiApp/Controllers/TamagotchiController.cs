using System.Collections.Generic;
using PokechiApp.Models;
using PokechiApp.Services;
using PokechiApp.Views;

namespace PokechiApp.Controllers
{
    public class TamagotchiController
    {
        private TamagotchiView menu { get; set; }
        private PokemonAPIService pokemonApiService { get; set; }
        private List<PokemonResults> petsDisponiveis { get; set; }
        private List<PokemonDetailsResult> petsAdotados { get; set; }

        public TamagotchiController()
        {
            menu = new TamagotchiView();
            pokemonApiService = new PokemonAPIService();
            //petsDisponiveis = pokemonApiService.GetPetsDisponiveis();
            petsAdotados = new List<PokemonDetailsResult>();
        }

        public void Play()
        {

        }
    }
}
