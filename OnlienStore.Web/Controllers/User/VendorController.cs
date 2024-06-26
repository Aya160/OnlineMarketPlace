using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;

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
    }
}
