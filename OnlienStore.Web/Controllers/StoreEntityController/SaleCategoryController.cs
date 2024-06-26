using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleCategoryController : ControllerBase
    {
        public SaleCategoryRepo<SaleCategory> saleCategoryRepo { get; }
        public SaleCategoryController(SaleCategoryRepo<SaleCategory> saleCategoryRepo)
        {
            this.saleCategoryRepo = saleCategoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetSaleCategoriesAlls()
        {
            return Ok(await saleCategoryRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSaleCategoryById(int id)
        {
            return Ok(await saleCategoryRepo.GetById(id));
        }
    }
}
