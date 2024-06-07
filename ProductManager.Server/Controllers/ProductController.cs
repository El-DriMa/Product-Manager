using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Server;
using ProductManager.Server.Data;
using ProductManager.Server.Models.DTO;
using ProductManager.Server.Repositories;

namespace ProductManager.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductController(AppDbContext dbContext,IMapper mapper,IProductRepository productRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productDomain = await productRepository.GetAllProductsAsync();
            return Ok(mapper.Map<List<ProductDTO>>(productDomain));
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var productDomain = await productRepository.GetByIdAsync(Id);
            if (productDomain == null) return NotFound();
            return Ok(mapper.Map<List<ProductDTO>>(productDomain));
        }
    }
}
