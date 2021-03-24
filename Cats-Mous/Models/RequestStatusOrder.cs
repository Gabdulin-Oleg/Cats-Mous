using System.Text;

namespace Cats_Mous.Models
{
    //Форма для запроса статуса заказа в системе оплаты
    public class RequestStatusOrder
    {
        public  string userName { get; set; }
        public string password { get; set; }
        public string orderId { get; set; }
        public RequestStatusOrder(Order order)
        {
            userName = "client8";
            password = ReceivingPassword(userName);
            orderId = order.orderId;
           
        }
        public static string ReceivingPassword(string username)
        {
            int result = 0;
            string str = $"{username}-spasem-mir";

            var arrayBytes = Encoding.ASCII.GetBytes(str);

            for (int i = 0; i < arrayBytes.Length; i++)
            {
                result += arrayBytes[i];
            }
            return result.ToString();
        }

    }
}
