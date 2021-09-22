using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Brew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int BreweryId { get; set; }

        public virtual Brewery Brewery { get; set; }
    }
}
