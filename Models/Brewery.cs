namespace Models
{
    public class Brewery
    {
        //Properties.
        public string Location {get; set;}

        //Constructors.
        public Brewery(){}

        public Brewery(string Location)
        {
            this.Location = Location;
        }
    }
}