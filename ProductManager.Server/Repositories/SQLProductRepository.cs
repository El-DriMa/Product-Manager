using ProductManager.Server.Models.Domain;
using ProductManager.Server.Data;
using ProductManager.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductManager.Server.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task UpdateAsync(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
