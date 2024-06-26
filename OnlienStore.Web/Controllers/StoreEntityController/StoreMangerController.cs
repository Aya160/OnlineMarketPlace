using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

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
    }
}
