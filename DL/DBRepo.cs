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

        public List<Brew> GetBrews(int BreweryId)
        {
            return (from b in _context.Brews
                    where b.BreweryId == BreweryId
                    select new Models.Brew(){
                        Id = b.BrewId,
                        Name = b.Name,
                        BreweryId = b.BreweryId,
                        Price = b.Price,
                        BrewQuantity = b.BrewQuantity
                    }).ToList();
        }

        public Customer AddCustomer(Models.Customer cust)
        {   
            Entity.Customer ec = new Entity.Customer()
            {
                Name = cust.Name
            };
            
            ec = _context.Add(ec).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Models.Customer(){
                Name = ec.Name,
                Id = ec.CustomerId
            };
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

        public Brew UpdateBrewQuantity(Brew brew)
        {
            Entity.Brew updatedBrew = (from b in _context.Brews
                                        where b.BrewId == brew.Id
                                        select b).SingleOrDefault();

            updatedBrew.BrewQuantity = brew.BrewQuantity;

            Brew newerBrew = new Models.Brew(){
                Id = updatedBrew.BrewId,
                Name = updatedBrew.Name,
                BreweryId = updatedBrew.BreweryId,
                Price = updatedBrew.Price,
                BrewQuantity = updatedBrew.BrewQuantity
            };

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return newerBrew;
        }

        public Brew AddBrew(Brew brew)
        {
            Entity.Brew b = new Entity.Brew()
            {
                BreweryId = brew.BreweryId,
                Name = brew.Name,
                BrewQuantity = brew.BrewQuantity,
                Price = brew.Price

            };

            b = _context.Add(b).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return brew;
        }

        public Order PlaceOrder(int orderId)
        {
            Entity.Order eo = (from o in _context.Orders 
                                where o.OrderId == orderId
                                select o).SingleOrDefault();

            eo.OrderPlaced = true;

            Order returnedOrder = new Models.Order(){
                OrderId = eo.OrderId,
                CustomerId = eo.CustomerId,
                OrderPlaced = eo.OrderPlaced
            };

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return returnedOrder;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.Select(
                Customer => new Models.Customer() {
                    Id = Customer.CustomerId,
                    Name = Customer.Name
                }
            ).ToList();
        }

        public List<Order> GetOrders(Customer c)
        {
            return (from o in _context.Orders
                    where o.CustomerId == c.Id && 
                    o.OrderPlaced == true
                    select new Models.Order(){
                        OrderId = o.OrderId,
                        CustomerId = o.CustomerId,
                        OrderPlaced = o.OrderPlaced
                    }).ToList();
        }
    }
}