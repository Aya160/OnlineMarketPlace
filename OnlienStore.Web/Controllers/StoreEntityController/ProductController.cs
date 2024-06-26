using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.DTOs.StoreDTO;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepo<Product> productRepo;
        public ProductController(ProductRepo<Product> productRepo)
        {
            this.productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await productRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            return Ok(await productRepo.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            Product product = new()
            {
                Name = productDTO.Name,
                Price= productDTO.Price,
            };
            await productRepo.CreateAsync(product);
            string uri = Url.Action(nameof(GetProductById), new { id = product.Id });
            return Created(uri, "Created Succsessfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, ProductDTO productDTO)
        {
            var product = await productRepo.GetById(id);
            if (product is null) return NotFound(new ApiResponse(404, $"Uneable to find {productDTO.Name} Product"));
            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            await productRepo.UpdateAsync(id, product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await productRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
