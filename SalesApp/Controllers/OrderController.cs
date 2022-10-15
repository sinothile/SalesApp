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
        [HttpGet]
        public IActionResult Index(string orderJson)
        {
            var orders = JsonSerializer.Deserialize<OrderDTO>(orderJson);
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDTO order)
        {
            var newOrder = new Order
            {
                CustomerName = order.CustomerName,
                OrderDate = DateTime.Now,
                UserID = order.UserId,
                Discount = order.OrderItems.Select(x=> x.Price).Sum() > 200 ? 0.03 * (double)order.OrderItems.Select(x => x.Price).Sum() : order.OrderItems.Select(x => x.Price).Sum() > 500 ? 0.1 * (double)order.OrderItems.Select(x => x.Price).Sum() : 0,
                SalesValueExcludingVAT = 7,
                SalesValueIncludingVAT = 2,
                OrderDetails = order.OrderItems.Select(x => new OrderDetails
                {
                    ProductID = x.ProductId,
                    Quantity = x.Quantity,
                }).ToList()
            };

            var isOrderPlaced = await _orderService.PlaceOrder(newOrder);
            if (isOrderPlaced)
                return RedirectToAction("Index", "Products");

            return View(order);
        }
    }
}
