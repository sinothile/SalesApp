using System.ComponentModel;
using Microsoft.Build.Framework;

namespace SalesApp.Models
{
    public class OrderDTO
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public double Vat { get; set; }
        public List<OrderViewModel> OrderItems { get; set; }
    }
}
