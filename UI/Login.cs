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
                    
                        //Collect name and add to Customers DB.
                        Console.WriteLine("Welcome! What is your Name?");
                        string name = Console.ReadLine();
                        Customer c = new Customer(name);
                        _bl.AddCustomer(c);
                        CurrentCustomer = _bl.CheckCustomerExists(name);

                        //Set static CurrentCustomer to the customer that just logged in.
                        Order o = new Order(CurrentCustomer.Id);
                        CurrentOrder = _bl.CreateOrder(o);

                        Console.WriteLine();
                        Console.WriteLine($"Great, you are now logged in as {CurrentCustomer.ToString()}.");
                        Console.WriteLine("Happy Brew Finding!");
                        MenuFactory.GetMenu("shop menu").Start();
                        break;
                    case "1":
                        Console.WriteLine("Welcome Back! What is your Name?");
                        string n = Console.ReadLine();
                        
                        //Relating the Current customer to an order. **Creates a new order
                        //each time app is run. Can I figure out how to save an order?
                        CurrentCustomer = _bl.CheckCustomerExists(n);

                        try {
                            CurrentOrder = new Order(CurrentCustomer.Id);
                            CurrentOrder = _bl.CreateOrder(CurrentOrder);
                        } 
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine($"A {n} has never been here...but...");
                            goto case "0";
                        }

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