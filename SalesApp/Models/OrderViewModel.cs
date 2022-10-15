using System.ComponentModel;

namespace SalesApp.Models
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
    }
}
