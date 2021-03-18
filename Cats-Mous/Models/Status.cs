namespace Cats_Mous.Models
{
    public class Status
    {
        public int OrderStatus { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string OrderNumber { get; set; }
        public int Amount { get; set; }

    }
}
