using System;

namespace PokechiApp
{
    public class Narrator
    {
        string player = string.Empty;
        int pronome = 0; // 1 = he; 2 = she; 3 = they
        int optionMenu = 0; // 0 = default

        public void Welcome()
        {
            Console.WriteLine("******************************** ");
            Console.WriteLine("Bem vindo à central de pokemons! ");
            Console.WriteLine("******************************** ");
            Console.WriteLine("\nAqui você poderá escolher um pokemon para ser seu pet! Vamos começar?");

            Console.Write("Primeiro, digite seu nome: ");
            player = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Com qual pronome você gostaria de ser chamado? ");
            Console.Write("Digite 1 para ELE, 2 para ELA e 3 para ELU: ");

            while (pronome == 0)
            {
                pronome = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
            }

            if (pronome == 1)
                Console.WriteLine($"Seja bem vindo, {player}!\n");
            else if (pronome == 2)
                Console.WriteLine($"Seja bem vinda, {player}!\n");
            else
                Console.WriteLine($"Seja bem vinde, {player}!\n");

            Menu();
        }

        public void Menu()
        {
            Console.WriteLine(" *********************** ");
            Console.WriteLine(" *         MENU        * ");
            Console.WriteLine(" *********************** ");
            Console.WriteLine(" * 1 - Adoção de Pets  * ");
            Console.WriteLine(" * 2 - Pets adotados   * ");
            Console.WriteLine(" * 3 - Sair            * ");
            Console.WriteLine(" *********************** ");
            Console.WriteLine();
            
            while (optionMenu <= 0 || optionMenu > 3)
            {
                Console.Write("Digite a opção escolhida: ");
                optionMenu = Convert.ToInt16(Console.ReadLine());
            }

            if (optionMenu == 1)
            {
                Console.WriteLine("\n** Você escolheu Adoção de Pets! **");
                AdoptionOptions();
            }
            else if (optionMenu == 2)
            {
                Console.WriteLine("\n** Você escolheu Pets Adotados! **");
                AdoptedPets();
            }
            else
            {
                Console.WriteLine($"\n** Você escolheu Sair! Até logo, {player}! **");
            }
        }

        public void AdoptionOptions()
        {

        }

        public void AdoptedPets()
        {

        }
    }
}
