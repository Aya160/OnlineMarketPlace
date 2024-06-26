using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.Shipping
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompaniesPermissionsController : ControllerBase
    {
        private readonly ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo;

        public ShippingCompaniesPermissionsController(ShippingCompaniesPermissionsRepo<ShippingCompaniesPermissions> shippingCompaniesPermissionsRepo)
        {
            this.shippingCompaniesPermissionsRepo = shippingCompaniesPermissionsRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllshippingCompaniesPermissions()
        {
            return Ok(await shippingCompaniesPermissionsRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetShippingCompanytPermissionById(int id)
        {
            return Ok(await shippingCompaniesPermissionsRepo.GetById(id));
        }
    }
}
