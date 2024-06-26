using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Web.ErrorHandeling;

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
        public async Task<ActionResult> GetShippingCompanyPermissionsById(int id)
        {
            return Ok(await shippingCompaniesPermissionsRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShippingCompanyPermissions(int id)
        {
            try
            {
                await shippingCompaniesPermissionsRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
