using System;
using System.Collections.Generic;

namespace PokechiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Narrator narrator = new Narrator();
            PokemonApiService service = new PokemonApiService();
            List<PokemonResults> petsDisponiveis = new List<PokemonResults>();
            List<PokemonDetailsResult> petsAdotados = new List<PokemonDetailsResult>();

            narrator.Welcome();

            while (narrator.OptionMenu <= 0 || narrator.OptionMenu > 3)
            {
                Console.Write("Escolha uma opção: ");
                narrator.OptionMenu = Convert.ToInt16(Console.ReadLine());
            }

            if (narrator.OptionMenu == 1)
            {
                Console.WriteLine("\n** Você escolheu Adoção de Pets! **");
                //petsDisponiveis = service.GetPetsDisponiveis();
                narrator.AdoptionOptions(petsDisponiveis);
            }
            else if (narrator.OptionMenu == 2)
            {
                Console.WriteLine("\n** Você escolheu Pets Adotados! **");
                //narrator.AdoptedPets();
            }
            else
            {
                Console.WriteLine($"\n** Você escolheu Sair! Até logo, {narrator.Player}! **");
            }

            ///

            
        }
    }
}
