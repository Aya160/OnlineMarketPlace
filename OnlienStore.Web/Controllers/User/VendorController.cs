using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly VendorRepo<Vendor> vendorRepo;

        public VendorController(VendorRepo<Vendor> vendorRepo) 
        {
            this.vendorRepo = vendorRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllVendors()
        {
            return Ok(await vendorRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVendorById(int id)
        {
            return Ok(await vendorRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVendor(int id)
        {
            try
            {
                await vendorRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
