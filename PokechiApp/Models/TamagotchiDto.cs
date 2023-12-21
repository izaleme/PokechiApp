using System;
using System.Collections.Generic;
using System.Linq;

namespace PokechiApp.Models
{
    public class TamagotchiDto
    {
        public int Food { get; private set; }
        public int Humor { get; private set; }
        public int Energy { get; private set; }
        public int Health { get; private set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public List<Ability> Skills { get; set; }

        public TamagotchiDto()
        {
            var rand = new Random();
            Food = rand.Next(11);
            Humor = rand.Next(11);
            Energy = rand.Next(11);
            Health = rand.Next(11);
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

            Console.WriteLine("\nMascote alimentado! **"); ;
        }

        public void Brincar()
        {
            Humor = Math.Min(Humor + 3, 10);
            Energy = Math.Max(Energy - 2, 0);
            Food = Math.Max(Food - 1, 0);

            Console.WriteLine("\nMascote feliz! **");
        }

        public void Descansar()
        {
            Energy = Math.Min(Energy + 4, 10);
            Humor = Math.Max(Humor - 1, 0);

            Console.WriteLine("\nMascote a mimir! **");
        }

        public void Acariciar()
        {
            Humor = Math.Min(Humor + 2, 10);
            Health = Math.Min(Health - 1, 0);

            Console.WriteLine("\nMascote amado! **");
        }

        public void MostrarStatus()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("--> STATUS DO PET ");
            Console.WriteLine($"-> Alimentação: {Food}");
            Console.WriteLine($"-> Humor: {Humor}");
            Console.WriteLine($"-> Energia: {Energy}");
            Console.WriteLine($"-> Saúde: {Health}");
        }

        public class Skill
        {
            public string Name { get; set; }
        }
    }
}
