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

        public void AddCustomer(Customer cust)
        {
            _repo.AddCustomer(cust);
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

        public List<Brew> PlaceOrder(List<OrderItem> oiList)
        {
            return _repo.PlaceOrder(oiList);
        }
    }
}