using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int BrewId { get; set; }
        public int OrderQuantity { get; set; }

        public virtual Brew Brew { get; set; }
        public virtual Order Order { get; set; }
    }
}
