using ProductManager.Server.Data;
using ProductManager.Server.Models;
using ProductManager.Server.Models.Domain;
namespace ProductManager.Server.Repositories
{
    public interface IProductRepository 
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetByIdAsync(int Id);
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task Delete(int Id);

    }
}
