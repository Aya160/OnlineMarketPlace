using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Web.DTOs.ShippingDTO;
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
        [HttpPost]
        public async Task<ActionResult<ShippingCompaniesPermissionsDTO>> CreateShippingCompaniesPermissions(ShippingCompaniesPermissionsDTO shippingCompaniesPermissionsDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            ShippingCompaniesPermissions shippingCompaniesPermissions = new()
            {
                Permission = shippingCompaniesPermissionsDTO.Permission,
                DeliverPrice = shippingCompaniesPermissionsDTO.DeliverPrice
            };
            await shippingCompaniesPermissionsRepo.CreateAsync(shippingCompaniesPermissions);
            string uri = Url.Action(nameof(GetShippingCompanyPermissionsById), new { id = shippingCompaniesPermissions.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ShippingCompaniesPermissionsDTO>> UpdateShippingCompanies(int id, ShippingCompaniesPermissionsDTO shippingCompaniesPermissionsDTO)
        {
            var shippingCompaniesPermissions = await shippingCompaniesPermissionsRepo.GetById(id);
            if (shippingCompaniesPermissions is null) return NotFound(new ApiResponse(404));
            shippingCompaniesPermissions.Permission = shippingCompaniesPermissionsDTO.Permission;
            shippingCompaniesPermissions.DeliverPrice = shippingCompaniesPermissionsDTO.DeliverPrice;
            await shippingCompaniesPermissionsRepo.UpdateAsync(id, shippingCompaniesPermissions);
            return Ok(shippingCompaniesPermissions);
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
