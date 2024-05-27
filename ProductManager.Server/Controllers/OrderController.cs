using Microsoft.AspNetCore.Mvc;
using ProductManager.Server;
using AutoMapper;
using ProductManager.Server.Data;
using ProductManager.Server.Repositories;
using ProductManager.Server.Models.DTO;

namespace ProductManager.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderController(AppDbContext dbContext,IOrderRepository orderRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderDomain = await orderRepository.GetAllOrdersAsync();
            return Ok(mapper.Map<List<OrderDTO>>(orderDomain));
        }
    }
}
