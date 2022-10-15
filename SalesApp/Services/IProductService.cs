using SalesApp.Models;

namespace SalesApp.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProducts();
    }
}
