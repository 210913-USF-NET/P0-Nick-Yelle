using System;

namespace UI
{
    public class ShopMenu : IMenu
    {
        public void Start()
        {
            bool exit = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine("How would you like to shop?");
                Console.WriteLine("[1] Shop Brews");
                Console.WriteLine("[2] Shop Locations");
                Console.WriteLine("[3] Shop Breweries");
                Console.WriteLine("[x] Back to Start Menu");

                switch(Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("You're shopping Brews.");
                        break;

                    case "2":
                        Console.WriteLine("You're shopping Locations.");
                        break;

                    case "3":
                        Console.WriteLine("You're shopping Breweries.");
                        break;
                    case "x":
                        exit = true;
                        Console.WriteLine("Bye.");
                        break;
                    default:
                        Console.WriteLine("I don't understand.");
                        break;
                }
            } while (!exit);
        }
    }
}