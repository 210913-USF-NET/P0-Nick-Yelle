using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface ISRepo
    {
        List<Brewery> GetBreweries();

        /// <summary>
        /// Gets a list of Brews depending on what kind of input recieved.
        /// int > List of Brews by Brewery
        /// no input > List of all Brews in Brews DB
        /// </summary>
        /// <returns>List of Brews</returns>
        List<Brew> GetBrews();

        List<Brew> GetBrews(int BreweryId);

        Customer AddCustomer(Customer cust);

        Customer CheckCustomerExists(string name);

        Order CreateOrder(Order order);

        OrderItem AddBrewToOrder(Order order, Brew brew, int quantity);

        List<OrderItem> GetOrderItems(int orderId);

        Brew GetBrewById(int brewId);

        Brew UpdateBrewQuantity(Brew brew);

        Brew AddBrew(Brew brew);

        Order PlaceOrder(int orderId);

        List<Customer> GetCustomers();

        List<Order> GetOrders(Customer c);
    }
}