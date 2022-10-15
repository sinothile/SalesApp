namespace SalesApp.Models
{
    public class OrderDetailsViewModel
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public OrderViewModel Order { get; set; }
    }
}
