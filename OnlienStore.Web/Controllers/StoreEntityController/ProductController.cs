using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

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
    }
}
