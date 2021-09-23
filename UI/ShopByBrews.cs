using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

namespace UI
{
    public class ShopByBrews : IMenu
    {
        private ISBL _bl;

        public ShopByBrews(ISBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            bool exit = false;

            Console.WriteLine();
            GetBrews();


            Console.WriteLine();
            Console.WriteLine("Which Brew would you like to add to your order?");
            Console.WriteLine("[x] Back");

            string brewIndex = Console.ReadLine();

            
        }
        private List<Brew> GetBrews()
        {
            List<Brew> allBrews = _bl.GetBrews();
            if(allBrews.Count == 0)
            {
                Console.WriteLine("There are no Brews.");
            }
            else
            {
                for(int i = 0; i < allBrews.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {allBrews[i].ToString()}");
                }
            }
            return allBrews;
        }
    }
}