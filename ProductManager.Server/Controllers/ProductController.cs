using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManager.Server;
using ProductManager.Server.Data;
using ProductManager.Server.Models.Domain;
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
            return Ok(mapper.Map<ProductDTO>(productDomain));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO createProductDTO)
        {
            var model = mapper.Map<Product>(createProductDTO);
            model = await productRepository.CreateAsync(model);
            var dto = mapper.Map<CreateProductDTO>(model);

            return CreatedAtAction(nameof(GetById), new {Id=model.Id}, dto);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO updateProductDTO)
        {
            var product = await productRepository.GetByIdAsync(updateProductDTO.Id);

            if (product == null) return NotFound();
      
            if(updateProductDTO.ProductName != null) product.ProductName = updateProductDTO.ProductName;
            if(updateProductDTO.UnitPrice!=null) product.UnitPrice = updateProductDTO.UnitPrice;
            if(updateProductDTO.Package!=null) product.Package= updateProductDTO.Package;
            product.SupplierId = updateProductDTO.SupplierId;

            await productRepository.UpdateAsync(product);
            return Ok(new { Message = "Data edited successfully" });

        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var product= await productRepository.GetByIdAsync(Id);
            if (product == null) return NotFound();

            try
            {
                await productRepository.Delete(Id);
                return Ok(new { message = "Product deleted successfully" });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Cannot delete product as it is referenced by other records.");
            }
        } 
    }
}
