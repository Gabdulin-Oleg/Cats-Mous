using Cats_Mous.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cats_Mous.DBCats_Mous;

namespace Cats_Mous.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.AllOrders = Operations.ReadSuccessfulOrders();
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Donate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Donate(Order order)
        {
            Operations.Creat(order);

            order = await SettingOrder.RegistredOrder(order);
            Operations.UpDate(order);

            return Redirect(order.formUrl);
        }

        public IActionResult PaymentСonfirmation(string OrderNumber)
        {
            Order order = Operations.Read(OrderNumber);
            order.OrderStatus = 7;
            Task.Run(() => SettingOrder.ChekStatusAsync(order));

            return Redirect("/Home/Index");
        }
    }
}
