using System;
using System.Linq;
using System.Xml.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace PokechiApp.Models
{
    public class TamagotchiDto
    {
        #region Attributes/Properties

        private string strPetName = string.Empty;

        public int Food { get; private set; }
        public int Humor { get; private set; }
        public int Energy { get; private set; }
        public int Health { get; private set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<Ability> Skills { get; set; }
        public string Name
        {
            get { return ToTitleCase(strPetName); }
            set { strPetName = ToTitleCase(value); }
        }
       
        #endregion

        #region Methods

        public TamagotchiDto()
        {
            var rand = new Random();
            Food = rand.Next(11);
            Humor = rand.Next(11);
            Energy = rand.Next(11);
            Health = rand.Next(11);
        }

        private string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public void AtualizarPropriedades(PokemonDetailsResult pokemonDetails)
        {
            Name = pokemonDetails.Name;
            Height = pokemonDetails.Height;
            Weight = pokemonDetails.Weight;
            Skills = pokemonDetails.Abilities.Select(a => new Ability { Name = a.Ability.Name }).ToList();
        }

        public void Alimentar()
        {
            Food = Math.Min(Food + 2, 10);
            Energy = Math.Max(Energy - 1, 0);

            Console.WriteLine("\n**Mascote alimentado!**");
        }

        public void Brincar()
        {
            Humor = Math.Min(Humor + 3, 10);
            Energy = Math.Max(Energy - 2, 0);
            Food = Math.Max(Food - 1, 0);

            Console.WriteLine("\n**Mascote feliz!**");
        }

        public void Descansar()
        {
            Energy = Math.Min(Energy + 4, 10);
            Humor = Math.Max(Humor - 1, 0);

            Console.WriteLine("\n**Mascote a mimir!**");
        }

        public void Carinho()
        {
            Humor = Math.Min(Humor + 2, 10);
            Health = Math.Min(Health - 1, 0);

            Console.WriteLine("\n**Mascote amado!**");
        }

        public void MostrarStatus()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("--> STATUS DO PET ");

            // Alimentação
            if (Food >= 9) Console.WriteLine($"-> Fome: {strPetName} está de barriga cheia!");
            else if (Food <= 2) Console.WriteLine($"-> Fome: {strPetName} está morrendo de fome!");
            else if (Food < 6) Console.WriteLine($"-> Fome: {strPetName} está com fome!");
            else Console.WriteLine($"-> Fome: {strPetName} está bem alimentado!");
            
            // Humor
            if (Humor >= 9) Console.WriteLine($"-> Humor: {strPetName} está radiante!");
            else if (Humor <= 4) Console.WriteLine($"-> Humor: {strPetName} está triste!");
            else Console.WriteLine($"-> Humor: {strPetName} está feliz!");

            // Energia
            if (Energy >= 9) Console.WriteLine($"-> Energia: {strPetName} está muito animado!");
            else if (Energy <= 2) Console.WriteLine($"-> Energia: {strPetName} precisa descansar!");
            else if (Energy <= 4) Console.WriteLine($"-> Energia: {strPetName} está cansado!");
            else Console.WriteLine($"-> Energia: {strPetName} está animado!");

            // Saúde
            if (Health <= 2) Console.WriteLine($"-> Saúde: {strPetName} está muito doente!");
            else if (Health <= 4) Console.WriteLine($"-> Saúde: {strPetName} está doente!");
            else Console.WriteLine($"-> Saúde: {strPetName} está saudável!");
        }

        public class Skill
        {
            public string Name { get; set; }
        }

        #endregion
    }
}
