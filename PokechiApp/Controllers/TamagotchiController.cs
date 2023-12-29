using System;
using PokechiApp.Views;
using PokechiApp.Models;
using PokechiApp.Services;
using System.Collections.Generic;

namespace PokechiApp.Controllers
{
    public class TamagotchiController
    {
        #region Attributes/Properties

        private TamagotchiView menu { get; set; }
        private PokemonAPIService pokemonApiService { get; set; }
        private List<PokemonResults> petsDisponiveis { get; set; }
        private List<TamagotchiDto> petsAdotados { get; set; }

        #endregion

        #region Builders/Methods

        public TamagotchiController()
        {
            menu = new TamagotchiView();
            pokemonApiService = new PokemonAPIService();
            petsDisponiveis = pokemonApiService.GetAllPokemons();
            petsAdotados = new List<TamagotchiDto>();
        }

        public void Play()
        {
            menu.Welcome();

            while (true)
            {
                menu.ShowMenuPrincipal();
                int optionMenu = menu.ChooseMenuOption(1, 4);

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
                                        var tamagotchi = new TamagotchiDto();
                                        tamagotchi.AtualizarPropriedades(details);
                                        petsAdotados.Add(tamagotchi);

                                        Console.WriteLine("Parabéns! Você adotou um " + details.Name + "!");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("────▄████▄────");
                                        Console.WriteLine("──▄████████▄──");
                                        Console.WriteLine("──██████████──");
                                        Console.WriteLine("──▀████████▀──");
                                        Console.WriteLine("─────▀██▀─────");
                                        Console.WriteLine("──────────────\n");
                                    }
                                    break;

                                case 4:
                                    break;
                            }

                            if (optionMenu == 4) break;
                        }
                        break;

                    case 2:
                        if (petsAdotados.Count == 0)
                        {
                            Console.WriteLine("Você não tem nenhum pet adotado.");
                            break;
                        }

                        Console.WriteLine("\nEscolha um pet para interagir: ");
                        for (int i = 0; i < petsAdotados.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {petsAdotados[i].Name}");
                        }

                        int indiceMascote = menu.ChoosePokemon(petsDisponiveis);
                        TamagotchiDto mascoteEscolhido = petsAdotados[indiceMascote];

                        int optionInteraction = 0;
                        while (optionInteraction != 4)
                        {
                            menu.ShowInteractionMenu();
                            optionInteraction = menu.ChooseMenuOption(1, 4);

                            switch (optionInteraction)
                            {
                                case 1:
                                    mascoteEscolhido.MostrarStatus();
                                    break;
                                case 2:
                                    mascoteEscolhido.Alimentar();
                                    break;
                                case 3:
                                    mascoteEscolhido.Brincar();
                                    break;
                                case 4:
                                    break;
                            }
                        }
                        break;

                    case 3:
                        menu.ShowAdoptedPets(petsAdotados);
                        break;

                    case 4:
                        Console.WriteLine("Obrigado por jogar! Até a próxima!");
                        return;
                }
            }
        }

        #endregion
    }
}
