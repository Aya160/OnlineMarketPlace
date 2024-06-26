using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.ErrorHandeling;

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSaleCategory(int id)
        {
            try
            {
                await saleCategoryRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
