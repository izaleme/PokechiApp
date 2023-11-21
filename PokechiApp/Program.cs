/* Projeto: PokeChi App
 * Autora: Izabela Leme
 * Data Início: 21/11/2023
 * */

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using RestSharp;
using System.Net;

namespace PokechiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InvokeGet();
            //InvokePost()
        }

        private static void InvokeGet()
        {
            // Create a custom HttpClientHandler to ignore system proxy settings
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseProxy = false; // Disable the system proxy settings
            HttpClient proxy = new HttpClient(httpClientHandler);

            var client = new RestClient(proxy);
            RestRequest request = new RestRequest("https://pokeapi.co/api/v2/pokemon/", Method.Get); // All pokemons options

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
                Console.WriteLine(response.Content);
            else
                Console.WriteLine(response.ErrorMessage);

            Console.ReadKey();
        }

        private static void InvokePost()
        {

        }
    }
}
