using System;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using PokechiApp.Models;
using System.Collections.Generic;

namespace PokechiApp.Services
{
    public class PokemonAPIService
    {
        private readonly WebProxy myProxy = new WebProxy()
        {
            BypassProxyOnLocal = true,
            UseDefaultCredentials = true //, Credentials = new NetworkCredential(userName: "", password: "") // Se quiser passar o login do proxy
        };

        public List<PokemonResults> GetAllPokemons()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = true;
            httpClientHandler.Proxy = myProxy;

            var client = new RestClient(handler: httpClientHandler);
            RestRequest request = new RestRequest("https://pokeapi.co/api/v2/pokemon-species/", Method.Get); // All pokemons options
            var response = client.Execute(request);

            /* **** Tratando erro de conexão/retorno **** */
            var statusCodeAsInt = (int)response.StatusCode;
            if (statusCodeAsInt >= 500)
                throw new InvalidOperationException("A server error occurred: " + response.ErrorMessage, response.ErrorException);
            else if (statusCodeAsInt >= 400)
                throw new InvalidOperationException("Request could not be understood by the server: " + response.ErrorMessage, response.ErrorException);
            else if (statusCodeAsInt == 0)
                throw new InvalidOperationException("No response: " + response.ErrorMessage, response.ErrorException);
            /* ****************************************** */

            var pokeSpeciesResult = JsonConvert.DeserializeObject<PokemonSpeciesResults>(response.Content);
            return pokeSpeciesResult.Results;
        }

        public PokemonDetailsResult GetPokemonDetails(PokemonResults specie)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = true;
            httpClientHandler.Proxy = myProxy;

            var client = new RestClient(handler: httpClientHandler);
            var request = new RestRequest($"https://pokeapi.co/api/v2/pokemon/{specie.Name}", Method.Get); // Details of the chosen pokemon
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
        }
    }
}
