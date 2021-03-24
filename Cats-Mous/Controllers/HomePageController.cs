using Cats_Mous.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cats_Mous.DBCats_Mous;
using Cats_Mous.Repository;
using Cats_Mous.Interdaces;

namespace Cats_Mous.Controllers
{
    public class HomePageController : Controller
    {
        private IRepository operationDB;
        private ISettingOrder settingOrder;
        public HomePageController()
        {
           operationDB = new Operations();
           settingOrder = new SettingOrder();
        }

        public IActionResult Index()
        {
            ViewBag.AllOrders = operationDB.ReadSuccessfulOrders();
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }        

        public IActionResult PaymentСonfirmation(string OrderNumber)
        {
            
            Order order = operationDB.Read(OrderNumber);            
            Task.Run(() => settingOrder.ChekStatusAsync(order));

            return Redirect("/HomePage/Index");
        }
    }
}
