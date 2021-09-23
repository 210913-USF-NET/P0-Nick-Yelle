using System;
using System.Collections.Generic;
using BL;
using Models;

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
                Console.WriteLine("[1] Shop By Brewery.");
                Console.WriteLine("[2] Shop By Brews");
                Console.WriteLine("[x] Back to Start Menu");

                switch(Console.ReadLine())
                {
                    case "1":
                        MenuFactory.GetMenu("shopping by brewery").Start();
                        break;
                    case "2":
                        MenuFactory.GetMenu("shopping by brews").Start();
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