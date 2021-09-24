using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        //Properties.
        public int OrderId {get; set;}
        public int CustomerId{get; set;}
        public bool OrderPlaced{get; set;}

        //Constructors.
        public Order(int OrderId, int CustomerId)
        {
            this.OrderId = OrderId;
            this.CustomerId = CustomerId;
        }

        public override string ToString()
        {
            return $"OrderId {OrderId}, CustomerId {CustomerId}, OrderPlace {OrderPlaced}";
        }
    }
}