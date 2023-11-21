using System;
using System.Net;
using System.Net.Http;
using RestSharp;

using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace PokechiApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InvokeGet();
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
                ReadJSON(response.Content); //Console.WriteLine(response.Content);
            else
                Console.WriteLine(response.ErrorMessage);

            Console.ReadKey();
        }

        private static void ReadJSON(string content)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic result = serializer.DeserializeObject(content);

            Console.WriteLine(" *** Pokemons Disponíveis *** \n");

            foreach (KeyValuePair<string, object> entry in result)
            {
                var key = entry.Key;
                var value = entry.Value as string;
                Console.WriteLine(string.Format("{0} : {1}", key, value));
            }

            Console.WriteLine("");
            Console.WriteLine(serializer.Serialize(result));
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
