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

        public int BrewQuantity {get; set;}

        public string Brewery {get; set;}

        public int BreweryId {get; set;}

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

        public Brew(Brewery brewery, string name, int Price)
        {
            this.BreweryId = brewery.Id;
            this.Name = name;
            this.Price = Price;
        } 

        //Overriding ToString method.
        public override string ToString()
        {
            return $"{Name} ${Price}";
        }

        public string ToDescription()
        {
            return $"${Price} {Name} ({BrewQuantity})";
        }
    }
}
