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

        public async Task<Product?> GetByIdAsync(int Id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
