using System;
using Models;
using BL;
using System.Collections.Generic;

namespace UI
{
    public class ManBrewMenu : IMenu
    {
        private IBrews _bl;

        public ManBrewMenu(IBrews bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Create Brew");
                Console.WriteLine("[2] List Current Brews");
                Console.WriteLine("[x] Back to Manager Menu");

                switch(Console.ReadLine())
                {
                    case "1":
                        CreateBrew();
                        break;
                    case "2":
                        ListBrews();
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
            _bl.AddBrew(newBrew);
        }

        public void ListBrews()
        {
            List<Brew> allBrews = _bl.GetAllBrews();
            if(allBrews.Count == 0)
            {
                Console.WriteLine("There are no Brews.");
            }
            else
            {
                foreach(Brew brew in allBrews)
                {
                    Console.WriteLine(brew.ToString());
                }
            }
        }
    }
}