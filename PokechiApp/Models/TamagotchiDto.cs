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
            int oldFood = Food;
            int oldEnergy = Energy;

            Food = Math.Min(Food + 2, 10);
            Energy = Math.Max(Energy - 1, 0);

            Console.WriteLine("\nMascote alimentado!");
            Console.WriteLine($"Obteve +{Food - oldFood} de comida!");
            Console.WriteLine($"Perdeu {Math.Abs(Energy - oldEnergy)} de energia!");
        }

        public void Brincar()
        {
            int oldHumor = Humor;
            int oldEnergy = Energy;
            int oldFood = Food;

            Humor = Math.Min(Humor + 3, 10);
            Energy = Math.Max(Energy - 2, 0);
            Food = Math.Max(Food - 1, 0);

            Console.WriteLine("\nMascote feliz!");
            Console.WriteLine($"Obteve +{Humor - oldHumor} de humor!");
            Console.WriteLine($"Perdeu {Math.Abs(Energy - oldEnergy)} de energia!");
            Console.WriteLine($"Perdeu {Math.Abs(Food - oldFood)} de comida!");
        }

        public void Descansar()
        {
            int oldEnergy = Energy;
            int oldHumor = Humor;

            Energy = Math.Min(Energy + 4, 10);
            Humor = Math.Max(Humor - 1, 0);

            Console.WriteLine("\nMascote a mimir!");
            Console.WriteLine($"Obteve +{Energy - oldEnergy} de energia!");
            Console.WriteLine($"Perdeu {Math.Abs(Humor - oldHumor)} de humor!");
        }

        public void Carinho()
        {
            int oldHumor = Humor;
            int oldHealth = Health;

            Humor = Math.Min(Humor + 2, 10);
            Health = Math.Min(Health - 1, 0);

            Console.WriteLine("\nMascote amado!");
            Console.WriteLine($"Obteve +{Humor - oldHumor} de humor!");
            Console.WriteLine($"Perdeu {Math.Abs(Health - oldHealth)} de saúde!");
        }

        public void MostrarStatus()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("--> STATUS DO PET ");

            // Alimentação
            string strMsgFood;
            if (Food >= 9) strMsgFood = " está de barriga cheia!";
            else if (Food <= 2) strMsgFood = " está morrendo de fome!";
            else if (Food < 6) strMsgFood = " está com fome!";
            else strMsgFood = " está alimentado!";

            // Humor
            string strMsgHumor;
            if (Humor >= 9) strMsgHumor = " está radiante!";
            else if (Humor <= 4) strMsgHumor = " está triste!";
            else strMsgHumor = " está feliz!";

            // Energia
            string strMsgEnergia;
            if (Energy >= 9) strMsgEnergia = " está muito animado!";
            else if (Energy <= 2) strMsgEnergia = " está muito cansado!";
            else if (Energy <= 4) strMsgEnergia = " está cansado!";
            else strMsgEnergia = " está animado!";

            // Saúde
            string strMsgSaude;
            if (Health <= 2) strMsgSaude = " está muito doente!";
            else if (Health <= 4) strMsgSaude = " está doente!";
            else strMsgSaude = " está saudável!";

            Console.WriteLine($"--> Fome:    {Food} | {strPetName}{strMsgFood}");
            Console.WriteLine($"--> Humor:   {Humor} | {strPetName}{strMsgHumor}");
            Console.WriteLine($"--> Energia: {Energy} | {strPetName}{strMsgEnergia}");
            Console.WriteLine($"--> Saúde:   {Health} | {strPetName}{strMsgSaude}");
        }

        public class Skill
        {
            public string Name { get; set; }
        }

        #endregion
    }
}
