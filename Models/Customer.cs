using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        //Properties.
        public int Id { get; set; }
        public string Name {get; set;}

        //Constructors.
        public Customer(string Name)
        {
            this.Name = Name;
        }
    }
}