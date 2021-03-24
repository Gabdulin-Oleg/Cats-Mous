using Cats_Mous.DBCats_Mous;
using Cats_Mous.Interdaces;
using Cats_Mous.Models;
using Cats_Mous.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats_Mous.Controllers
{
    public class DonatPageController : Controller
    {
        private IRepository operationDB;
        private ISettingOrder settingOrder;
        public DonatPageController()
        {
            operationDB = new Operations();
            settingOrder =  new SettingOrder();
        }        
        public IActionResult Donate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Donate(Order order)
        {
                       
            IdOrder idOrder = await settingOrder.RegistredOrder(order);            

            return Redirect(idOrder.formUrl);
        }
    }
}
