using System;
using PokechiApp.Models;
using System.Collections.Generic;

namespace PokechiApp.Views
{
    public class TamagotchiView
    {
        #region Attributes/Properties

        public string Player { get; private set; }
        //public int Pronome { get; private set; }

        #endregion

        #region Methods

        public void Welcome()
        {
            Console.WriteLine("Bem Vindo à Central de \n");

            Console.WriteLine("######    #####   ### ###  ######   ### ###   #####   ##  ##    ######   ##### ");
            Console.WriteLine("### ###  ### ###   ## ###   ######  #######  ### ###  ### ###  ######    ##### ");
            Console.WriteLine("###  ##  ### ###   #####    ##      #######  ### ###  ### ###  ##        ##### ");
            Console.WriteLine("### ###  ##   ##  #####    ######   ##   ##  ##   ##  #### ##  #####     ####  ");
            Console.WriteLine("######   ##   ##  ####     #####    ### ###  ##   ##  ## ####   #####      ##  ");
            Console.WriteLine("###      ### ###  ######   ###      ### ###  ### ###  ### ###      ###    ###  ");
            Console.WriteLine(" ###     #######  ### ###  #######   ## ##   #######  ### ###   ######   ####  ");
            Console.WriteLine(" ###      #####   ### ###   #####    ## ##    #####    ##  ##  ######     ##   ");

            Console.WriteLine("\nAqui você poderá escolher um pokemon para ser seu pet! Vamos começar?");
            Console.Write("Como você quer ser chamado? ");

            Player = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Seja bem vindo, {Player}!");

            /*  Depois arrumo essa parte dos pronomes, por enquanto é coisa extra e desnecessária
            Console.WriteLine("Com qual pronome você gostaria de ser chamado? ");
            Console.Write("Digite 1 para ELE, 2 para ELA ou 3 para ELU: ");

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
            */

        }

        public void ShowMenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("******************************* ");
            Console.WriteLine("*             MENU            * ");
            Console.WriteLine("******************************* ");
            Console.WriteLine("* 1 - Adoção de Pets          * ");
            Console.WriteLine("* 2 - Interagir com seus Pets * ");
            Console.WriteLine("* 3 - Pets Adotados           * ");
            Console.WriteLine("* 4 - Sair do jogo            * ");
            Console.WriteLine("******************************* ");
            Console.WriteLine("******************************* ");
            Console.WriteLine();

            Console.Write("Escolha uma opção: ");
        }

        public void ShowAdoptionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("******************************** ");
            Console.WriteLine("*        ADOÇÃO DE PETS        * ");
            Console.WriteLine("******************************** ");
            Console.WriteLine("* 1 - Pokemons Disponíveis     * ");
            Console.WriteLine("* 2 - Sobre um Pokemon         * ");
            Console.WriteLine("* 3 - Adotar um Pokemon        * ");
            Console.WriteLine("* 4 - Voltar ao Menu Principal * ");
            Console.WriteLine("******************************** ");
            Console.WriteLine("******************************** ");
            Console.WriteLine();

            Console.Write("Escolha uma opção: ");
        }

        public void ShowInteractionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("******************************* ");
            Console.WriteLine("*      MENU DE INTERAÇÃO      * ");
            Console.WriteLine("******************************* ");
            Console.WriteLine("* 1 - Verificar status do Pet * ");
            Console.WriteLine("* 2 - Alimentar o Pet         * ");
            Console.WriteLine("* 3 - Brincar com o Pet       * ");
            Console.WriteLine("* 4 - Voltar                  * ");
            Console.WriteLine("******************************* ");
            Console.WriteLine("******************************* ");
            Console.WriteLine();

            Console.Write("Escolha uma opção: ");
        }

        public void ShowPetsDisponiveis(List<PokemonResults> species)
        {
            Console.WriteLine("\n*****************************");
            Console.WriteLine("Pets disponíveis para adoção:");
            for (int i = 0; i < species.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + species[i].Name);
            }
        }

        public void ShowDetalhesEspecie(PokemonDetailsResult specie)
        {
            Console.WriteLine("\n--------------------");
            Console.WriteLine("Detalhes do Pokemon:");
            Console.WriteLine($"Nome: {specie.Name}");
            Console.WriteLine($"Peso: {specie.Weight}");
            Console.WriteLine($"Altura: {specie.Height}");

            Console.WriteLine("Habilidades: ");
            foreach (var abilityDetail in specie.Abilities)
            {
                Console.WriteLine("- " + abilityDetail.Ability.Name);
            }
        }

        public void ShowAdoptedPets(List<TamagotchiDto> adoptedPets)
        {
            if (adoptedPets.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum pet.");
            }
            else
            {
                Console.WriteLine("\n*******************");
                Console.WriteLine("Seus pets adotados:");

                for (int i = 0; i < adoptedPets.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + adoptedPets[i].Name);
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

        public int ChoosePokemon(List<PokemonResults> specie)
        {
            Console.WriteLine("\n-------------------------------");

            int escolha;
            while (true)
            {
                Console.Write($"Escolha uma espécie pelo número (1 a {specie.Count}): ");
                try
                {
                    if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= specie.Count) break;
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro: " + e.Message);
                }
            }

            return escolha - 1; // Ajuste para índice baseado em 0
        }

        public bool ConfirmarAdocao()
        {
            Console.Write("\nVocê gostaria de adotar esse pokemon? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        #endregion
    }
}
