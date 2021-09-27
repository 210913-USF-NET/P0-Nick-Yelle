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

        List<Brew> GetBrews();

        void AddCustomer(Customer cust);

        Customer CheckCustomerExists(string name);

        Order CreateOrder(Order order);

        OrderItem AddBrewToOrder(Order order, Brew brew, int quantity);

        List<OrderItem> GetOrderItems(int orderId);

        Brew GetBrewById(int brewId);

        List<Brew> PlaceOrder(List<OrderItem> oiList);
    }
}