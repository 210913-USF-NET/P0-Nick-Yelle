using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using DL;

namespace BL
{
    public class ShopLogic : ISBL
    {
        //Properties.
        private ISRepo _repo;

        //Constructor.
        public ShopLogic(ISRepo repo)
        {
            _repo = repo;
        }

        public List<Brewery> GetBreweries()
        {
            return _repo.GetBreweries();
        }

        public List<Brew> GetBrews()
        {
            return _repo.GetBrews();
        }

        public List<Brew> GetBrews(int BreweryId)
        {
            return _repo.GetBrews(BreweryId);
        }

        public Customer AddCustomer(Customer cust)
        {
            return _repo.AddCustomer(cust);
        }

        public Customer CheckCustomerExists(string name)
        {
            return _repo.CheckCustomerExists(name);
        }

        public Order CreateOrder(Order order)
        {
            return _repo.CreateOrder(order);
        }

        public OrderItem AddBrewToOrder(Order order, Brew brew, int quantity)
        {
            return _repo.AddBrewToOrder(order, brew, quantity);
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            return _repo.GetOrderItems(orderId);
        }

        public Brew GetBrewById(int Id)
        {
            return _repo.GetBrewById(Id);
        }

        public Brew UpdateBrewQuantity(Brew brew)
        {
            return _repo.UpdateBrewQuantity(brew);
        }

        public Brew AddBrew(Brew brew)
        {
            return _repo.AddBrew(brew);
        }

        public Order PlaceOrder(int orderId)
        {
            return _repo.PlaceOrder(orderId);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public List<Order> GetOrders(Customer cust)
        {
            return _repo.GetOrders(cust);
        }

        public Brewery AddBrewery(Brewery b)
        {
            return _repo.AddBrewery(b);
        }

        public Brewery GetBreweryById(int id)
        {
            return _repo.GetBreweryById(id);
        }
    }
}