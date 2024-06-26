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
        [HttpPost]
        public async Task<ActionResult<StoreManagerPermissionsDTO>> CreateStoreManagerPermission(StoreManagerPermissionsDTO storeManagerPermissionsDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            StoreManagerPermissions storeManagerPermissions = new()
            {
                Permission = storeManagerPermissionsDTO.Permission,
                PermissionStatus = storeManagerPermissionsDTO.PermissionStatus,
            };
            await storeMangerPermissionRepo.CreateAsync(storeManagerPermissions);
            string uri = Url.Action(nameof(GetStoreMangerPermissionById), new { id = storeManagerPermissions.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StoreDTO>> UpdateStoreManagerPermission(int id, StoreManagerPermissionsDTO storeManagerPermissionsDTO)
        {
            var storeMangerPermission = await storeMangerPermissionRepo.GetById(id);
            if (storeMangerPermission is null) return NotFound(new ApiResponse(404));
            storeMangerPermission.Permission = storeManagerPermissionsDTO.Permission;
            storeMangerPermission.PermissionStatus = storeManagerPermissionsDTO.PermissionStatus;
            await storeMangerPermissionRepo.UpdateAsync(id, storeMangerPermission);
            return Ok(storeMangerPermission);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStoreMangerPermission(int id)
        {
            try
            {
                await storeMangerPermissionRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
