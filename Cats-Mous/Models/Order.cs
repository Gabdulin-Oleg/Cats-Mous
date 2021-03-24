using System.Text;

namespace Cats_Mous.Models
{
    public class Order
    {
        public int Id { get; set; }        
        public string orderNumber { get; set; }
        public string orderId { get; set; }
        public int? Amount { get; set; }
        public string Description { get; set; }
        public int? OrderStatus { get; set; }
    }
}
