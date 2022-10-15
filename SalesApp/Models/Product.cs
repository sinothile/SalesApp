using System.ComponentModel;

namespace SalesApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Unit Price")]
        public double UnitPrice { get; set; }
        public bool IsChecked { get; set; }
    }
}
