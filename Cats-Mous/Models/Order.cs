using System.Text;

namespace Cats_Mous.Models
{
    public class Order
    {
        public int Id { get; set; }        
        public string OrderNumber { get; set; }
        public string orderId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Amount { get; set; }
        public string formUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string failUrl { get; set; }
        public string Description { get; set; }
        public int? OrderStatus { get; set; }
        public int? errorCode { get; set; }
        public string errorMessage { get; set; }      
        
        public Order()
        {
            UserName = "client7";
            Password = ReceivingPassword(UserName);
            failUrl = "https://localhost:44369/Home/Error";
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
