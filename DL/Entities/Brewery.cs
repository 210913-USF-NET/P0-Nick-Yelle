using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Brewery
    {
        public Brewery()
        {
            Brews = new HashSet<Brew>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Brew> Brews { get; set; }
    }
}
