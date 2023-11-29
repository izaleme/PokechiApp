using System;
using System.Collections.Generic;

namespace PokechiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TamagotchiView narrator = new TamagotchiView();
            PokemonResults pokemon = new PokemonResults();
            PokemonAPIService service = new PokemonAPIService();
            List<PokemonResults> petsDisponiveis = new List<PokemonResults>();
            List<PokemonDetailsResult> petsAdotados = new List<PokemonDetailsResult>();

            narrator.Welcome();

            while (narrator.OptionMenu <= 0 || narrator.OptionMenu > 3)     // MENU PRINCIPAL
            {
                Console.Write("Escolha uma opção: ");
                narrator.OptionMenu = Convert.ToInt16(Console.ReadLine());
            }

            if (narrator.OptionMenu == 1)
            {
                Console.WriteLine("\n** Você escolheu Adoção de Pets! **");
                narrator.MenuAdoption();

                if (Convert.ToInt16(narrator.ChooseMenuOption(1, 3)) == 1)      // ADOÇÃO DE PETS
                {
                    //petsDisponiveis = service.GetPetsDisponiveis();
                    //narrator.AdoptionOptions(petsDisponiveis);
                }
                else if (Convert.ToInt16(narrator.ChooseMenuOption(1, 3)) == 2)     // DETALHES SOBRE O PET
                {
                    Console.Write("Qual o nome do pokemon que você quer saber mais sobre? R: ");
                    pokemon.Name = Console.ReadLine();
                    narrator.PetDetails(service.PetDetails(pokemon));

                    Console.Write($"\nDigite 1 para adotar {pokemon.Name} ou 2 para voltar: ");
                    if (Convert.ToInt16(narrator.ChooseMenuOption(1, 2)) == 1)      // ADOTAR O PET
                    {
                        // ADOTAR
                    }
                    else
                    {
                        narrator.MenuAdoption();
                    }
                }
                else if (Convert.ToInt16(narrator.ChooseMenuOption(1, 3)) == 3)     // ADOTAR UM PET
                {
                    
                }
                else
                {
                    narrator.Menu();
                }
            }
            else if (narrator.OptionMenu == 2)
            {
                Console.WriteLine("\n** Você escolheu Pets Adotados! **");
                // MOSTRAR PETS ADOTADOS
                //narrator.AdoptedPets();
            }
            else
            {
                Console.WriteLine($"\n** Você escolheu Sair! Até logo, {narrator.Player}! **");
            }

        }
    }
}
