using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class OrderItem
    {
        //Properties.
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int BrewId { get; set; }
        public int OrderQuantity { get; set; }

        //Constructors.
        public OrderItem(){}
    }
}