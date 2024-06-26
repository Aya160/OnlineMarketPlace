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

        [HttpPost]
        public async Task<ActionResult<StoreDTO>> CreateStore(StoreDTO storeDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            Store store = new()
            {
                Name = storeDTO.Name,
                Location = storeDTO.Location,
            };
            await storeRepo.CreateAsync(store);
            string uri = Url.Action(nameof(GetStoreById), new { id = store.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StoreDTO>> UpdateStore(int id, StoreDTO storeDTO)
        {
            var store = await storeRepo.GetById(id);
            if (store is null) return NotFound(new ApiResponse(404));
            store.Name = storeDTO.Name;
            store.Location = storeDTO.Location;
            await storeRepo.UpdateAsync(id, store);
            return Ok(store);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStore(int id)
        {
            try
            {
                await storeRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
