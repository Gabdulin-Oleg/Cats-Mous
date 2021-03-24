using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats_Mous.Models
{
    public class StatusOrder
    {
        // Форма для получения Статусв Заказа в системе оплаты
        public int orderStatus { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public string orderNumber { get; set; }
        public int amount { get; set; }
    }
}
