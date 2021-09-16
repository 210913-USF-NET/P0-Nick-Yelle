using System;

namespace Models
{
    public class Brew
    {
        //properties
        public Brewery brewery { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }

        //constructors
        public Brew(){}

        public Brew(Brewery brewery)
        {
            this.brewery = brewery;
        }

        public Brew(string Desk)
        {
            this.Desc = Desc;
        }

        public Brew(double Price)
        {
            this.Price = Price;
        }
    }
}
