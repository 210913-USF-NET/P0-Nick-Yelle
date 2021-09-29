namespace Models
{
    public class Brewery
    {
        //Properties.
        public string Name { get; set; }
        public string City {get; set;}
        public string State {get; set;}
        public int Id {get; set;}

        //Constructors.
        public Brewery(){}

        public Brewery(string Name)
        {
            this.Name = Name;
        }
        public Brewery(string Name, string City, string State)
        {
            this.Name = Name;
            this.City = City;
            this.State = State;
        }

        public override string ToString()
        {
            return $"{Name} in {City}, {State}";
        }
    }
}