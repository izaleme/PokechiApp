using PokechiApp.Controllers;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {
            TamagotchiController tamagotchiContoller = new TamagotchiController();
            tamagotchiContoller.Play();
        }
    }

}