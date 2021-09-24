using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

namespace UI
{
    public class Login : IMenu
    {
        private ISBL _bl;

        public Login(ISBL bl)
        {
            _bl = bl;
        }

        public static Customer CurrentCustomer;
        public static Order CurrentOrder;
        public void Start()
        {
            bool exit = false;
            bool beenHere = false;

            while (!exit && !beenHere)
            {
                Restart:
                beenHere = true;
                Console.WriteLine();
                Console.WriteLine("Have you been here before?");
                Console.WriteLine("[0] No");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[X] Exit");


                switch(Console.ReadLine().ToUpper())
                {
                    case "0":
                        Console.WriteLine("Welcome! What is your Name?");
                        string name = Console.ReadLine();
                        Customer c = new Customer(name);
                        _bl.AddCustomer(c);
                        break;
                    case "1":
                        Console.WriteLine("Welcome Back! What is your Name?");
                        string n = Console.ReadLine();

                        CurrentCustomer = _bl.CheckCustomerExists(n);

                        if(CurrentCustomer == null)
                        {   
                            Console.WriteLine("No one with that name has ever been here...but....");
                            goto case "0";
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Great, you are now logged in as {CurrentCustomer.ToString()}.");
                            Console.WriteLine("Happy Brew Finding!");
                        }

                        MenuFactory.GetMenu("shop menu").Start();
                        break;
                    case "X":
                        exit = true;
                        Console.WriteLine("Bye.");
                        break;
                    default:
                        Console.WriteLine("I don't understand.");
                        goto Restart;
                }
            } 
        }

        // private void AddCustomer(Customer cust)
        // {
        //     _bl.AddCustomer(cust);
        // }
    }
}