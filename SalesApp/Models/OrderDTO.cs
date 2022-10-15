using Microsoft.Build.Framework;

namespace SalesApp.Models
{
    public class OrderDTO
    {
        public int UserId { get; set; } 
        [Required]
        public string CustomerName { get; set; }
        public List<OrderViewModel> OrderItems { get; set; }
        public double TotalPrice { get; set; }
        public double Vat { get; set; }
    }
}
