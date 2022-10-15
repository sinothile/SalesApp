using SalesApp.Models;

namespace SalesApp.Services
{
    public interface IOrderService
    {
        Task<bool> PlaceOrder(Order order);
    }
}
