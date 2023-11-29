using System;
using System.Collections.Generic;

namespace PokechiApp
{
    public class TamagotchiView
    {
        #region Attributes/Properties

        public string Player { get; private set; }
        public int Pronome { get; private set; }
        public int OptionMenu { get; set; }

        #endregion

        public void Welcome()
        {
            Console.WriteLine("******************************** ");
            Console.WriteLine("Bem vindo à central de pokemons! ");
            Console.WriteLine("******************************** ");
            Console.WriteLine("\nAqui você poderá escolher um pokemon para ser seu pet! Vamos começar?");

            Console.Write("Primeiro, digite seu nome: ");
            Player = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Com qual pronome você gostaria de ser chamado? ");
            Console.Write("Digite 1 para ELE, 2 para ELA e 3 para ELU: ");

            while (Pronome == 0)
            {
                Pronome = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
            }

            if (Pronome == 1)
                Console.WriteLine($"Seja bem vindo, {Player}!\n");
            else if (Pronome == 2)
                Console.WriteLine($"Seja bem vinda, {Player}!\n");
            else
                Console.WriteLine($"Seja bem vinde, {Player}!\n");

            OptionMenu = 0;
            Menu();
        }

        public void Menu()
        {
            Console.WriteLine(" **************************** ");
            Console.WriteLine(" *           MENU           * ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine(" * 1 - Adoção de Pets       * ");
            Console.WriteLine(" * 2 - Pets Adotados        * ");
            Console.WriteLine(" * 3 - Sair do jogo         * ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine();
        }

        public void MenuAdoption()
        {
            Console.WriteLine(" **************************** ");
            Console.WriteLine(" *      ADOÇÃO DE PETS      * ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine(" * 1 - Pokemons Disponíveis * ");
            Console.WriteLine(" * 2 - Sobre um Pokemon     * ");
            Console.WriteLine(" * 3 - Fazer uma Adoção     * ");
            Console.WriteLine(" * 4 - Voltar               * ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine();

            Console.Write("Escolha uma opção: ");
        }

        public void AdoptionOptions(List<PokemonResults> species)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Pets disponíveis para adoção:");
            for (int i = 0; i < species.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + species[i].Name);
            }
        }

        public void PetDetails(PokemonDetailsResult pet)
        {
            Console.WriteLine("\n********************");
            Console.WriteLine("Detalhes do Pokemon:");
            Console.WriteLine($"Nome: {pet.Name}");
            Console.WriteLine($"Peso: {pet.Weight}");
            Console.WriteLine($"Altura: {pet.Height}");

            Console.WriteLine("Habilidades: ");
            foreach (var abilityDetail in pet.Abilities)
            {
                Console.WriteLine("- " + abilityDetail.Ability.Name);
            }
        }

        public void AdoptedPets(List<PokemonDetailsResult> adoptedPets)
        {
            Console.WriteLine("\n*******************");
            Console.WriteLine("Seus pets adotados:");
            if (adoptedPets.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum pet.");
            }
            else
            {
                for (int i = 0; i < adoptedPets.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + adoptedPets[i].Name);
                }
            }
        }

        public int ChooseMenuOption(int min, int max)
        {
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < min || option > max)
            {
                Console.Write($"Escolha inválida. Por favor, escolha uma opção entre {min} e {max}: ");
            }
            return option;
        }

        public int ChoosePokemon(List<PokemonResults> species)
        {
            int escolha;
            while (true)
            {
                Console.WriteLine("\n");
                Console.Write("Escolha uma opção: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= species.Count)
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                    else break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro: " + e.Message);
                }
            }

            return escolha - 1;
        }
    }
}
