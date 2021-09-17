using System;

namespace Models
{
    public class Brew
    {
        //properties
        public string Name { get; set; }

        //constructors
        public Brew(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }

    }
}
