using System;
using System.Net;
using System.Net.Http;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using PokechiApp;
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

            Console.WriteLine("Bem vindo! Escolha um Tamagotchi: ");
            for (int i = 0; i < pokeSpeciesResult.Results.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokeSpeciesResult.Results[i].Name}");
            }

            // Obter a escolha do jogador
            int escolha;

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
                    Console.WriteLine("ocorreu um erro: " + e.Message);
                }
            }

            // Obter as características do Pokémon escolhido
            request = new RestRequest($"https://pokeapi.co/api/v2/pokemon/{escolha}", Method.Get);
            response = client.Execute(request);

            // Mostrar as características ao jogador
            Console.WriteLine(response.Content);
        }
    }
}
