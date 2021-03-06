using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface ISRepo
    {
        /// <summary>
        /// Selects all Brewery Objects from Breweries DB, 
        /// converts retrieved objects to List.
        /// </summary>
        /// <returns>List of Brewery Objects</returns>
        List<Brewery> GetBreweries();
        /// <summary>
        /// Searches Breweries DB, Selects Brewery Brewery that matches the id passed in.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Selected Brewery Object</returns>
        Brewery GetBreweryById(int id);
        /// <summary>
        /// Selects all Brew Objects in Brews DB,
        /// converts retrieved objects to List.
        /// </summary>
        /// <returns>List of Brew Objects</returns>
        List<Brew> GetBrews();
        /// <summary>
        /// Searches Brews DB for all Brews with matching Brewery Id.
        /// </summary>
        /// <param name="BreweryId"></param>
        /// <returns>List of Brews</returns>
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

        Brewery AddBrewery(Brewery b);
    }
}