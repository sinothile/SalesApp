namespace SalesApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public double SalesValueExcludingVAT { get; set; }
        public double SalesValueIncludingVAT { get; set; }
        public double Discount { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
