using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreMangerController : ControllerBase
    {
        private readonly StoreMangerRepo<StoreManager> storeMangerRepo;
        public StoreMangerController(StoreMangerRepo<StoreManager> storeMangerRepo) 
        {
            this.storeMangerRepo = storeMangerRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllStoreMangers()
        {
            return Ok(await storeMangerRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStoreMangerById(int id)
        {
            return Ok(await storeMangerRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStoreManger(int id)
        {
            try
            {
                await storeMangerRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
