using Cats_Mous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats_Mous.Interdaces
{
    public interface IRepository
    {
        public void Creat(Order order);
        public void UpDate(Order order);
        public Order Read(string OrderNumber);
        public void Delete(Order order);
        public List<Order> ReadSuccessfulOrders();


    }
}
