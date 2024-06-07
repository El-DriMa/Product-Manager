using ProductManager.Server.Models.Domain;
using ProductManager.Server.Data;
using ProductManager.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductManager.Server.Models.DTO;

namespace ProductManager.Server.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public SQLProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetByIdAsync(int Id)
        {
            return await dbContext.Products.Where(x => x.Id == Id).ToListAsync();
        }
    }
}
