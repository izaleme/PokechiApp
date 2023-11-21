using System;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;

namespace PokechiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a custom HttpClientHandler to ignore system proxy settings
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = false; // Disable the system proxy settings
            HttpClient proxy = new HttpClient(httpClientHandler);

            var client = new RestClient(proxy);
            RestRequest request = new RestRequest("https://pokeapi.co/api/v2/pokemon-species/", Method.Get); // All pokemons options

            var response = client.Execute(request);
            var pokeSpeciesResult = JsonConvert.DeserializeObject<PokemonSpeciesResults>(response.Content);

            Console.WriteLine("************************\n");
            Console.WriteLine("Bem vindo à central de pokemons! ");
            for (int i = 0; i < pokeSpeciesResult.Results.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokeSpeciesResult.Results[i].Name}");
            }

            int escolha; // Player choice

            while (true)
            {
                Console.WriteLine("\n");
                Console.Write("Escolha um número: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokeSpeciesResult.Results.Count)
                    {
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                    }
                    else break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro: " + e.Message);
                }
            }

            // Obter as características do Pokémon escolhido
            request = new RestRequest($"https://pokeapi.co/api/v2/pokemon/{escolha}", Method.Get);
            response = client.Execute(request);

            var pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
            var choosedOne = pokeSpeciesResult.Results[escolha - 1];

            // Mostra as características
            Console.WriteLine("\n************************\n");
            Console.WriteLine($"Você escolheu {choosedOne.Name.ToUpper()}!\n");
            Console.WriteLine($"Detalhes:");
            Console.WriteLine($"- Nome: {choosedOne.Name}");
            Console.WriteLine($"- Peso: {pokemonDetalhes.Weight}");
            Console.WriteLine($"- Altura: {pokemonDetalhes.Height}");

            Console.WriteLine("\nHabilidades: ");
            foreach (var abilityDetail in pokemonDetalhes.Abilities)
            {
                Console.WriteLine("- " + abilityDetail.Ability.Name);
            }

            Console.WriteLine("\n************************\n");
        }
    }
}
