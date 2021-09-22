using System;
using Serilog;

namespace Models
{
    public class Brew
    {
        //properties
        public string Name { get; set; }
        public int Id {get; set;}
        public int Price {get; set;}

        //constructors
        public Brew(){}
        public Brew(string name)
        {   
            Log.Debug("Creating brew.");
            this.Name = name;
        }
        public Brew(int Price) : this()
        {
            this.Price = Price;
        }

        //Overriding ToString method.
        public override string ToString()
        {
            return $"Name: {Name}";
        }

    }
}
