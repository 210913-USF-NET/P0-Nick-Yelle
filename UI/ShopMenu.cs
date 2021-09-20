using System;
using BL;

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
                Console.WriteLine("");
                Console.WriteLine("[1] Shop Brews");
                Console.WriteLine("[x] Back to Start Menu");

                switch(Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Here are all the brews.");
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