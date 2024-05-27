using Microsoft.AspNetCore.Mvc;
using ProductManager.Server.Models;
using ProductManager.Server.Models.Domain;
using ProductManager.Server.Models.DTO;

namespace ProductManager.Server.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
    }
}
