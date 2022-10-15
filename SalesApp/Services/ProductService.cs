using Newtonsoft.Json;
using SalesApp.Models;

namespace SalesApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClient;

        public ProductService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var client = _httpClient.CreateClient("httpClient");
            var response = await client.GetAsync("api/Products");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(jsonResponse);

            return products.Select(prod => new ProductViewModel
            {
                CategoryName = prod.CategoryName,
                ProductId = prod.ProductId,
                UnitPrice = prod.UnitPrice,
                Quantity = 1,
                ProductName = prod.ProductName,
                OrderDetails = prod.OrderDetails,
            }).ToList();
        }
    }
}
