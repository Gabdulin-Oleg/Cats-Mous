using Cats_Mous.DBCats_Mous;
using Cats_Mous.Interdaces;
using Cats_Mous.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cats_Mous.Repository
{
    public class Operations : IRepository
    {
        private Context db;

        public Operations()
        {
            db = new Context();
        }

        public void Creat(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public void UpDate(Order order)
        {
            //var res = db.Orders.Find(order.Id);
            db.Orders.Update(order);
            db.SaveChanges();
        }
        public Order Read(string OrderNumber)
        {
            if (OrderNumber != null)
            {
                return db.Orders.Select(o => o).Where(o => o.orderNumber == OrderNumber).Single();
            }
            return null;
        }
        public void Delete(Order order)
        {
            db.Orders.Remove(order);
            db.SaveChanges();

        }
        public List<Order> ReadSuccessfulOrders()
        {
            List<Order> orders = db.Orders.Select(o => o).Where(o => o.OrderStatus == 2).ToList();
            if (orders != null)
            {
                return orders;
            }
            return null;
        }

    }
}
