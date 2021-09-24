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
            Console.WriteLine(":::: All Brews ::::");
            List<Brew> brewList = GetBrews();
            Console.WriteLine("[x] Back");

            Console.WriteLine("Select a Brew to add to your order.");

            int brewIndex = Int32.Parse(Console.ReadLine());

            Brew chosenBrew = brewList[brewIndex];

            Console.WriteLine();
            Console.WriteLine($"You have chosen {chosenBrew.ToName()}");
            Console.WriteLine();
            Console.WriteLine("How many would you like?");
            int chosenQuantity = Int32.Parse(Console.ReadLine());

            //Create Orders. What if it 
            // CreateOrder()

        }

        // private void CreateOrder();
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
                    Console.WriteLine($"[{i}] {allBrews[i].ToString()}");
                }
            }
            return allBrews;
        }
    }
}