using ProductManager.Server.Data;
using ProductManager.Server.Models;
using ProductManager.Server.Models.Domain;
namespace ProductManager.Server.Repositories
{
    public interface IProductRepository 
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product?>> GetByIdAsync(int Id);
    }
}
