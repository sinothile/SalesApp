using SalesApp.Models;

namespace SalesApp.Services
{
    public interface IProductService
    {
        Task<ProductViewModel> GetAllProducts();
    }
}
