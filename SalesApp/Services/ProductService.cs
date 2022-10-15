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
        public async Task<ProductViewModel> GetAllProducts()
        {
            var client = _httpClient.CreateClient("httpClient");
            var response = await client.GetAsync("api/Products");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);

            return new ProductViewModel
            {
                Products = products
            };
        }
    }
}
