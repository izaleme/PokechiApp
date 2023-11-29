using System;
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
            petsDisponiveis = pokemonApiService.GetAllPokemons();
            petsAdotados = new List<PokemonDetailsResult>();
        }

        public void Play()
        {
            menu.Welcome();

            while (true)
            {
                menu.ShowMenuPrincipal();
                int optionMenu = menu.ChooseMenuOption(1, 3);

                switch (optionMenu)
                {
                    case 1:
                        while (true)
                        {
                            menu.ShowAdoptionMenu();
                            optionMenu = menu.ChooseMenuOption(1, 4);

                            switch (optionMenu)
                            {
                                case 1:
                                    menu.ShowPetsDisponiveis(petsDisponiveis);
                                    break;

                                case 2:
                                    menu.ShowPetsDisponiveis(petsDisponiveis);
                                    int indicePokemon = menu.ChoosePokemon(petsDisponiveis);
                                    PokemonDetailsResult details = pokemonApiService.GetPokemonDetails(petsDisponiveis[indicePokemon]);
                                    menu.ShowDetalhesEspecie(details);
                                    break;

                                case 3: // ADOÇÃO
                                    menu.ShowPetsDisponiveis(petsDisponiveis);
                                    indicePokemon = menu.ChoosePokemon(petsDisponiveis);
                                    details = pokemonApiService.GetPokemonDetails(petsDisponiveis[indicePokemon]);
                                    menu.ShowDetalhesEspecie(details);
                                    if (menu.ConfirmarAdocao())
                                    {
                                        petsAdotados.Add(details);
                                        Console.WriteLine("Parabéns! Você adotou um " + details.Name + "!");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("────▄████▄────");
                                        Console.WriteLine("──▄████████▄──");
                                        Console.WriteLine("──██████████──");
                                        Console.WriteLine("──▀████████▀──");
                                        Console.WriteLine("─────▀██▀─────");
                                        Console.WriteLine("──────────────");
                                    }
                                    break;

                                case 4:
                                    break;
                            }
                        }

                    case 2:
                        menu.ShowAdoptedPets(petsAdotados);
                        break;

                    case 3:
                        Console.WriteLine("Obrigado por jogar! Até a próxima!");
                        return;
                }
            }
        }
    }
}
