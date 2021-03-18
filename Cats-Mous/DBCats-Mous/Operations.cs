using Cats_Mous.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cats_Mous.DBCats_Mous
{
    public static class Operations
    {
        public static void Creat(Order order)
        {
            using (Context db = new Context())
            {
                
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
        public static void UpDate(Order order)
        {
            using (Context db = new Context())
            {
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }
        public static Order Read(string OrderNumber)
        {
            using (Context db = new Context())
            {
                if (OrderNumber != null)
                {
                    var order = from item in db.Orders
                                where item.OrderNumber == OrderNumber
                                select item;
                    return order.Single();
                }
                return null;
            }
        }
        public static void Delete(Order order)
        {
            using (Context db = new Context())
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
        public static List<Order> ReadSuccessfulOrders()
        {
            using (Context db = new Context())
            {
                var orders = from item in db.Orders
                             where item.OrderStatus == 2
                             select item;
                return orders.ToList();
            }
        }

    }
}
