using System;

namespace UI
{
    public class ManMenu
    {
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to manage?");
                Console.WriteLine("[1] Manage Brews");
                Console.WriteLine("[2] Manage Breweries");
                Console.WriteLine("[x] Back to Start Menu");

                switch(Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("You would like to Manage Brews.");
                        break;
                    case "2":
                        Console.WriteLine("You would like to Manage Breweries.");
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