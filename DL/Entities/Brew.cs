using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Brew
    {
        public Brew()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int BrewId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int BreweryId { get; set; }
        public int BrewQuantity { get; set; }

        public virtual Brewery Brewery { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
