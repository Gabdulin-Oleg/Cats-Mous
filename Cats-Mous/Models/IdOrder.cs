using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats_Mous.Models
{
    //Форма получения ID заказа в системк оплаты
    public class IdOrder
    {
        public string orderId { get; set; }
        public string formUrl { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
    }
}
