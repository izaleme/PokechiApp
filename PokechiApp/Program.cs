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
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            } else {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }

        private static void InvokePost()
        {

        }
    }
}