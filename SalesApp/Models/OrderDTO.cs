namespace SalesApp.Models
{
    public class OrderDTO
    {
        public int UserId { get; set; } 
        public string CustomerName { get; set; }
        public List<OrderViewModel> OrderItems { get; set; }
    }
}
