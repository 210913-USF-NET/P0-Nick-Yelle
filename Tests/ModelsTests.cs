using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Xunit;

namespace Tests
{
    public class ModelsTests
    {
        [Fact]
        public void AllModelsShouldCreate()
        {
            //Arrange and Act.
            Brew brew = new Brew();
            Brewery brewery = new Brewery();
            Customer customer = new Customer();
            Order order = new Order();
            OrderItem oi = new OrderItem();
            
            //Assert.
            Assert.NotNull(brew);
            Assert.NotNull(brewery);
            Assert.NotNull(customer);
            Assert.NotNull(order);
            Assert.NotNull(oi);
        }
    }
}