using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;
using SalesApp.Services;

namespace SalesApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult Index(List<Product> products)
        {
            var selectedProducts = products.Where(x => x.IsChecked && x.Quantity > 0).Select(x => x).ToList();
            var orderItems = selectedProducts.Select(x => new OrderViewModel
            {
                Price = x.UnitPrice,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Quantity = x.Quantity
            }).ToList();

            var totalPrice = orderItems.Select(x => (x.Price*x.Quantity)).Sum();
            var vat = 0.15 * totalPrice;
            var price = totalPrice + vat;

            return View(new OrderDTO
            {
                CustomerName = null,
                OrderItems = orderItems,
                TotalPrice = price,
                Vat = vat
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDTO order)
        {
            var userId = int.Parse(HttpContext.Request.Cookies["userId"]);
            var newOrder = new Order
            {
                CustomerName = order.CustomerName,
                OrderDate = DateTime.Now,
                UserID = userId,
                Discount = order.OrderItems.Select(x => (x.Price * x.Quantity)).Sum() > 200 ? 0.03 * (double)order.OrderItems.Select(x => (x.Price * x.Quantity)).Sum() : order.OrderItems.Select(x => (x.Price * x.Quantity)).Sum() > 500 ? 0.1 * (double)order.OrderItems.Select(x => (x.Price * x.Quantity)).Sum() : 0,
                SalesValueExcludingVAT = order.TotalPrice - order.Vat,
                SalesValueIncludingVAT = order.TotalPrice,
                OrderDetails = order.OrderItems.Select(x => new OrderDetails
                {
                    ProductID = x.ProductId,
                    Quantity = x.Quantity
                }).ToList()
,
            };

            var isOrderPlaced = await _orderService.PlaceOrder(newOrder);
            if (isOrderPlaced)
                return RedirectToAction("Index", "Products");

            return View(order);
        }
    }
}
