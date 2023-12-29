using System;
using System.Linq;
using System.Collections.Generic;

namespace PokechiApp.Models
{
    public class TamagotchiDto
    {
        #region Attributes/Properties

        public string Name { get; set; }
        public int Food { get; private set; }
        public int Humor { get; private set; }
        public int Energy { get; private set; }
        public int Health { get; private set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<Ability> Skills { get; set; }

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

        public void AtualizarPropriedades(PokemonDetailsResult pokemonDetails)
        {
            Name = pokemonDetails.Name;
            Height = pokemonDetails.Height;
            Weight = pokemonDetails.Weight;
            Skills = pokemonDetails.Abilities.Select(a => new Ability { Name = a.Ability.Name }).ToList();
        }

        private int RandomStatus(int intMax)
        {
            int randomStatus = new Random().Next(1,intMax);
            return randomStatus;
        }

        public void Alimentar()
        {
            int oldFood = Food;
            int oldHealth = Health;
            int oldEnergy = Energy;

            Food = Math.Min(Food + RandomStatus(4), 10);
            Energy = Math.Max(Energy - RandomStatus(3), 0);
            Health = Math.Min(Health + RandomStatus(3), 10);

            Console.WriteLine($"\nVocê alimentou {Name}!");
            Console.WriteLine($"Obteve +{Food - oldFood} de comida!");
            Console.WriteLine($"Obteve +{Health - oldHealth} de saúde!");
            Console.WriteLine($"Perdeu {Energy - oldEnergy} de energia!");
        }

        public void Brincar()
        {
            int oldHumor = Humor;
            int oldEnergy = Energy;
            int oldFood = Food;

            Humor = Math.Min(Humor + RandomStatus(4), 10);
            Energy = Math.Max(Energy - RandomStatus(3), 0);
            Food = Math.Max(Food - RandomStatus(3), 0);

            Console.WriteLine($"\nVocê brincou com {Name}!");
            Console.WriteLine($"Obteve +{Humor - oldHumor} de humor!");
            Console.WriteLine($"Perdeu {Energy - oldEnergy} de energia!");
            Console.WriteLine($"Perdeu {Food - oldFood} de comida!");
        }

        public void Carinho()
        {
            int oldHumor = Humor;
            Humor = Math.Min(Humor + RandomStatus(3), 10);

            Console.WriteLine($"\nVocê fez carinho em {Name}!");
            Console.WriteLine($"Obteve +{Humor - oldHumor} de humor!");
        }

        public void Descansar()
        {
            int oldEnergy = Energy;
            int oldHumor = Humor;

            Energy = Math.Min(Energy + RandomStatus(4), 10);
            Humor = Math.Max(Humor - RandomStatus(3), 0);

            Console.WriteLine($"\n{Name} está a mimir!");
            Console.WriteLine($"Obteve +{Energy - oldEnergy} de energia!");
            Console.WriteLine($"Perdeu {Humor - oldHumor} de humor!");
        }

        public void Medicina()
        {
            int oldHealth = Health;
            int oldHumor = Humor;

            Health = Math.Min(Health + RandomStatus(6), 10);
            Humor = Math.Max(Humor - RandomStatus(4), 0);

            Console.WriteLine($"\nVocê deu remédios a {Name}!");
            Console.WriteLine($"Obteve +{Health - oldHealth} de saúde!");
            Console.WriteLine($"Perdeu {Humor - oldHumor} de humor!");
        }

        public void MostrarStatus()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("--> STATUS DO PET ");

            // Alimentação
            string strMsgFood;
            if (Food >= 9) strMsgFood = " está de barriga cheia!";
            else if (Food <= 2) strMsgFood = " está morrendo de fome!";
            else if (Food < 6) strMsgFood = " está com fome!";
            else strMsgFood = " está alimentado!";

            // Humor
            string strMsgHumor;
            if (Humor >= 9) strMsgHumor = " ama você!"; // ヾ(≧▽≦*)o\\
            else if (Humor <= 4) strMsgHumor = " está de mal humor!"; // ≡(▔﹏▔)≡
            else strMsgHumor = " está feliz!"; // (*^▽^*)

            // Energia
            string strMsgEnergia;
            if (Energy >= 8) strMsgEnergia = " está com muita energia!";
            else if (Energy <= 2) strMsgEnergia = " precisa descansar!";
            else if (Energy <= 4) strMsgEnergia = " está cansado!";
            else strMsgEnergia = " está com energia!";

            // Saúde
            string strMsgSaude;
            if (Health <= 2) strMsgSaude = " está se sentindo muito mal!";
            else if (Health <= 4) strMsgSaude = " não se sente bem!";
            else strMsgSaude = " está se sentindo bem!";

            Console.WriteLine($"--> Fome:    {Food} | {Name}{strMsgFood}");
            Console.WriteLine($"--> Humor:   {Humor} | {Name}{strMsgHumor}");
            Console.WriteLine($"--> Energia: {Energy} | {Name}{strMsgEnergia}");
            Console.WriteLine($"--> Saúde:   {Health} | {Name}{strMsgSaude}");
        }

        public class Skill
        {
            public string Name { get; set; }
        }

        #endregion
    }
}
