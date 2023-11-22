using System;
using System.Collections.Generic;

namespace PokechiApp
{
    public class Narrator
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
            Console.WriteLine(" * 2 - Pets adotados        * ");
            Console.WriteLine(" * 3 - Sair                 * ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine(" **************************** ");
            Console.WriteLine();
        }

        public void AdoptionOptions(List<PokemonResults> species)
        {
            Console.WriteLine("Pets disponíveis para adoção:");
            for (int i = 0; i < species.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + species[i].Name);
            }
        }

        public void PetDetails(PokemonDetailsResult pet)
        {
            Console.WriteLine($"Detalhes do Pokemon:");
            Console.WriteLine($"Nome: {pet.Name}");
            Console.WriteLine($"Peso: {pet.Weight}");
            Console.WriteLine($"Altura: {pet.Height}");

            Console.WriteLine("Habilidades: ");
            foreach (var abilityDetail in pet.Abilities)
            {
                Console.WriteLine("- " + abilityDetail.Ability.Name);
            }
        }

        public void AdoptedPets(PokemonDetailsResult details)
        {

        }

        //public int ChooseMenuOption()
        //{
        //    int option;
        //    while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4) // 4 pq será adicionada +1 opção (detalhes do pet)
        //    {
        //        Console.Write("Escolha inválida. Por favor, escolha uma opção entre 1 e 4: ");
        //    }
        //    return option;
        //}

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
