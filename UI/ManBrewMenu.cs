using System;
using Models;

namespace UI
{
    public class ManBrewMenu : IMenu
    {

        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Create Brew");
                Console.WriteLine("[x] Back to Manager Menu");

                switch(Console.ReadLine())
                {
                    case "1":
                        CreateBrew();
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
        
        private void CreateBrew()
        {
            Console.WriteLine("Creating new Brew.");
            Console.WriteLine("Brew Name:");
            string name = Console.ReadLine();
            Brew newBrew = new Brew(name);
            Console.WriteLine($"You created {name}");
        }
    }
}