using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Entity = DL.Entities;

namespace DL
{
    public class DBRepo : ISRepo
    {

        //Fields.
        private Entity.P0DBContext _context;

        //Constructor.
        public DBRepo(Entity.P0DBContext context)
        {
            _context = context;
        }

        //Methods.
        public List<OrderItem> GetOrderItems(int orderId)
        {
            return (from oi in _context.OrderItems 
                        where oi.OrderId == orderId 
                        select new Models.OrderItem{
                            OrderItemId = oi.OrderItemId,
                            OrderId = oi.OrderId,
                            BrewId = oi.BrewId,
                            OrderQuantity = oi.OrderQuantity
                        }).ToList();
        }
        public List<Brewery> GetBreweries()
        {
            return _context.Breweries.Select(
                Brewery => new Models.Brewery() {
                    Id = Brewery.BreweryId,
                    Name = Brewery.Name,
                    State = Brewery.State,
                    City = Brewery.City
                }
            ).ToList();
        }

        public List<Brew> GetBrews()
        {
            return _context.Brews.Select(
                Brew => new Models.Brew() {
                    Id = Brew.BrewId,
                    Name = Brew.Name,
                    Price = Brew.Price,
                    BrewQuantity = Brew.BrewQuantity
                }
            ).ToList();
        }

        public void AddCustomer(Models.Customer cust)
        {   
            Entity.Customer ec = new Entity.Customer()
            {
                Name = cust.Name
            };
            
            ec = _context.Add(ec).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();
        }

        public Customer CheckCustomerExists(string name)
        {
            List<Customer> custList = _context.Customers.Select(
                Customer => new Models.Customer() {
                    Id = Customer.CustomerId,
                    Name = Customer.Name,
                }
            ).ToList();

            foreach(Customer c in custList)
            {
                if (c.Name == name) { return c; }
            }
            return null;
        }

        public Order CreateOrder(Order order)
        {
            //Converting Model Object to Entity Object.
            Entity.Order eo = new Entity.Order()
            {
                CustomerId = order.CustomerId,
                OrderPlaced = false
            };

            eo = _context.Add(eo).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            Order returnOrder = new Order()
            {
                CustomerId = eo.CustomerId,
                OrderId = eo.OrderId,
                OrderPlaced = eo.OrderPlaced
            };
            return returnOrder;
        }

        public OrderItem AddBrewToOrder(Order order, Brew brew, int quantity)
        {
            Entity.OrderItem eoi = new Entity.OrderItem()
            {
                OrderId = order.OrderId,
                BrewId = brew.Id,
                OrderQuantity = quantity
            };

            eoi = _context.Add(eoi).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            OrderItem returnOrderItem = new OrderItem()
            {
                OrderItemId = eoi.OrderItemId,
                OrderId = eoi.OrderId,
                BrewId = eoi.BrewId,
                OrderQuantity = eoi.OrderQuantity
            };
            return returnOrderItem;
        }

        public Brew GetBrewById(int brewId)
        {
            List<Brew> list = (from oi in _context.Brews 
                    where oi.BrewId == brewId
                    select new Models.Brew(){
                        Name = oi.Name,
                        Id = oi.BrewId,
                        BreweryId = oi.BreweryId,
                        Price = oi.Price,
                        BrewQuantity = oi.BrewQuantity
                    }).ToList();

            //Returning first item in list because I know the query will return exactly 1 Brew.
            return list[0];
        }

        public List<Brew> PlaceOrder(List<OrderItem> oiList)
        {
            List<Brew> updatedBrewList = new List<Brew>();
            
            foreach(OrderItem oi in oiList)
            {
                //Retrieve Brew/Product.
                List<Brew> retrievedBrew = (from b in _context.Brews
                                where b.BrewId == oi.BrewId
                                select new Models.Brew(){
                                    BreweryId = b.BreweryId,
                                    Id = b.BrewId,
                                    Name = b.Name,
                                    Price = b.Price,
                                    BrewQuantity = b.BrewQuantity
                                }).ToList();
            
                //Update Brew/Product inventory.
                retrievedBrew[0].BrewQuantity -= oi.OrderQuantity;
                //Add Brew to updatedBrewList.
                updatedBrewList.Add(retrievedBrew[0]);
                _context.SaveChanges();

                _context.ChangeTracker.Clear();
                }
            return updatedBrewList;
        }
    }
}