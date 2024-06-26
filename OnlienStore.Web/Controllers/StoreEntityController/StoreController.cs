using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreRepo<Store> storeRepo;

        public StoreController(StoreRepo<Store> storeRepo)
        {
            this.storeRepo = storeRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllStores()
        {
            return Ok(await storeRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStoreById(int id)
        {
            return Ok(await storeRepo.GetById(id));
        }
    }
}
