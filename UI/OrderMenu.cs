using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace UI
{
    public class OrderMenu : IMenu
    {
        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Current Order");
            int CurrentCustId = Login.CurrentCustomer.Id; //CurrentCustomer is a static variable in Login. 

            
        }
    }
}