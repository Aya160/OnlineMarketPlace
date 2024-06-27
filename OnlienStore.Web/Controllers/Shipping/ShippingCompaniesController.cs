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
        [HttpPost]
        public async Task<ActionResult<ShippingCompaniesDTO>> CreateShippingCompanies(ShippingCompaniesDTO shippingCompaniesDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            ShippingCompanies shippingCompanies = new()
            {
                CompanyName = shippingCompaniesDTO.CompanyName,
                CompanyNO = shippingCompaniesDTO.CompanyNO,
                ContractStartDate = shippingCompaniesDTO.ContractStartDate,
                ContractEndDate = shippingCompaniesDTO.ContractEndDate,
            };
            await shippingCompaniesRepo.CreateAsync(shippingCompanies);
            string uri = Url.Action(nameof(GetShippingCompanytById), new { id = shippingCompanies.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ShippingCompaniesDTO>> UpdateShippingCompanies(int id, ShippingCompaniesDTO shippingCompaniesDTO)
        {
            var shippingCompanies = await shippingCompaniesRepo.GetById(id);
            if (shippingCompanies is null) return NotFound(new ApiResponse(404));
            shippingCompanies.CompanyName = shippingCompaniesDTO.CompanyName;
            shippingCompanies.CompanyNO = shippingCompaniesDTO.CompanyNO;
            shippingCompanies.ContractStartDate = shippingCompaniesDTO.ContractStartDate;
            shippingCompanies.ContractEndDate = shippingCompaniesDTO.ContractEndDate;
            await shippingCompaniesRepo.UpdateAsync(id, shippingCompanies);
            return Ok(shippingCompanies);
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
