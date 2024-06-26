using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.Shipping
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompaniesController : ControllerBase
    {
        private readonly ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo;

        public ShippingCompaniesController(ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo)
        {
            this.shippingCompaniesRepo = shippingCompaniesRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllShippingCompanies()
        {
            return Ok(await shippingCompaniesRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetShippingCompanytById(int id)
        {
            return Ok(await shippingCompaniesRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShippingCompany(int id)
        {
            try
            {
                await shippingCompaniesRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
