namespace Models
{
    public class Brewery
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public Brewery(string Name, string Location)
        {
            this.Name = Name;
            this.Location = Location;
        }
    }
}