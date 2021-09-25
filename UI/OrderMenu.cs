using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BL;

namespace UI
{
    public class OrderMenu : IMenu
    {
        private ISBL _bl;
        public OrderMenu(ISBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("---Current Order---");
            int orderId = Login.CurrentOrder.OrderId;

            //Search orderitems table for all the orders with this order id.
            List<OrderItem> orderItems = GetOrderItems(orderId);
            if (orderItems.Count == 0)
            {
                Console.WriteLine("No Brews in Order :/");
            }
            else
            {
                foreach(OrderItem oi in orderItems)
                {
                    Console.WriteLine($"{oi.OrderQuantity} {GetBrewById(oi.BrewId)}");
                }
                Console.WriteLine("[$] To Place Current Order");
                Console.WriteLine("[x] Exit Order Menu");
            }

            switch(Console.ReadLine())
            {
                case "$":
                    PlaceOrder(orderItems);
                    break;
                default:
                    break;
            }
            
        }
        private List<Brew> PlaceOrder(List<OrderItem> oiList)
        {
            return _bl.PlaceOrder(oiList);
        }
        private List<OrderItem> GetOrderItems(int orderId)
        {
            return _bl.GetOrderItems(orderId);
        }
        private Brew GetBrewById(int brewId)
        {
            return _bl.GetBrewById(brewId);
        }
    }
}