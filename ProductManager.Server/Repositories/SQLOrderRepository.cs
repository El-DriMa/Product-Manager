using ProductManager.Server.Models.DTO;
using ProductManager.Server.Data;
using Microsoft.EntityFrameworkCore;
using ProductManager.Server.Models.Domain;

namespace ProductManager.Server.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        public readonly AppDbContext dbContext;
        public SQLOrderRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await dbContext.Orders.ToListAsync();
        }
    }
}
