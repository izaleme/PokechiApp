using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using PokechiApp.Models;

namespace PokechiApp.Services
{
    public class PokemonAPIService
    {
        private void Proxy(RestClientOptions options)
        {
            // Create a custom HttpClientHandler to ignore system proxy settings
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = false; // Disable the system proxy settings
            _ = new HttpClient(httpClientHandler);
        }

        public List<PokemonResults> GetAllPokemons()
        {
            var client = new RestClient(Proxy);
            RestRequest request = new RestRequest("https://pokeapi.co/api/v2/pokemon-species/", Method.Get); // All pokemons options
            RestResponse response = client.Execute(request);

            var pokeSpeciesResult = JsonConvert.DeserializeObject<PokemonSpeciesResults>(response.Content);
            return pokeSpeciesResult.Results;
        }

        public PokemonDetailsResult GetPokemonDetails(PokemonResults specie)
        {
            var client = new RestClient(Proxy);
            var request = new RestRequest($"https://pokeapi.co/api/v2/pokemon/{specie.Name}", Method.Get); // Details of the chosen pokemon
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
        }
    }
}
