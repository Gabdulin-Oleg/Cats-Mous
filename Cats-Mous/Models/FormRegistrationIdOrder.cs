using System.Text;

namespace Cats_Mous.Models
{
    //Форма для регистрации ID заказа в системe оплаты
    public class FormRegistrationIdOrder
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string orderNumber { get; set; }
        public int? amount { get; set; }
        public string returnUrl { get; set; }
        public string failUrl { get; set; }
        public FormRegistrationIdOrder(Order order)
        {
            userName = "client8";
            password = ReceivingPassword(userName);
            failUrl = "https://localhost:44369/HomePage/Error";
            amount = order.Amount;
            returnUrl = $" https://localhost:44369/HomePage/PaymentСonfirmation?orderNumber={order.Id}";
            orderNumber = order.orderNumber;
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
