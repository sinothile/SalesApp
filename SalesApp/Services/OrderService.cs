using System.Text;
using Newtonsoft.Json;
using SalesApp.Models;

namespace SalesApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _httpClient;
        public OrderService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> PlaceOrder(Order order)
        {
            var client = _httpClient.CreateClient("httpClient");
            var json = JsonConvert.SerializeObject(order);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Orders", stringContent);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
        }
    }
}
