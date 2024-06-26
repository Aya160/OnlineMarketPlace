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
        [HttpPost]
        public async Task<ActionResult<StoreManagerDTO>> CreateStoreManager(StoreManagerDTO storeManagerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            StoreManager storeManager = new()
            {
                StartAt = storeManagerDTO.StartAt,
            };
            await storeMangerRepo.CreateAsync(storeManager);
            string uri = Url.Action(nameof(GetStoreMangerById), new { id = storeManager.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StoreManagerDTO>> UpdateStoreManager(int id, StoreManagerDTO storeManagerDTO)
        {
            var storeManager = await storeMangerRepo.GetById(id);
            if (storeManager is null) return NotFound(new ApiResponse(404));
            storeManager.StartAt = storeManagerDTO.StartAt;
            await storeMangerRepo.UpdateAsync(id, storeManager);
            return Ok(storeManager);
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
