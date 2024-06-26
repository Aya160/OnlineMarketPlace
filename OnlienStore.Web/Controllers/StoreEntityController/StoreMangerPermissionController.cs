using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreMangerPermissionController : ControllerBase
    {
        private readonly StoreMangerPermissionRepo<StoreManagerPermissions> storeMangerPermissionRepo;

        public StoreMangerPermissionController(StoreMangerPermissionRepo<StoreManagerPermissions> storeMangerPermissionRepo)
        {
            this.storeMangerPermissionRepo = storeMangerPermissionRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllStoreMangerPermissions()
        {
            return Ok(await storeMangerPermissionRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStoreMangerPermissionById(int id)
        {
            return Ok(await storeMangerPermissionRepo.GetById(id));
        }
    }
}
