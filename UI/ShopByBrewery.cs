using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

namespace UI
{
    public class ShopByBrewery : IMenu
    {
        private ISBL _bl;

        public ShopByBrewery(ISBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool exit = false;

            Console.WriteLine();
            GetBreweries();


            Console.WriteLine();
            Console.WriteLine("Which Brewery would you like to Shop?");
            Console.WriteLine("[x] Back");

            string breweryIndex = Console.ReadLine();
        }
        private List<Brewery> GetBreweries()
        {
            List<Brewery> allBreweries = _bl.GetBreweries();
            if(allBreweries.Count == 0)
            {
                Console.WriteLine("There are no Breweries.");
            }
            else
            {
                for(int i = 0; i < allBreweries.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {allBreweries[i].ToString()}");
                }
            }
            return allBreweries;
        }
    }
}