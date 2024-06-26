using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleProductController : ControllerBase
    {
        public SaleProductRepo<SaleProduct> saleProductRepo { get; }
        public SaleProductController(SaleProductRepo<SaleProduct> saleProductRepo)
        {
            this.saleProductRepo = saleProductRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllSaleProducts()
        {
            return Ok(await saleProductRepo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSaleProductById(int id)
        {
            return Ok(await saleProductRepo.GetById(id));
        }
    }
}
