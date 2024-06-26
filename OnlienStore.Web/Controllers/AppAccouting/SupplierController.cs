using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SupplierRepo<Supplier> supplierRepo;

        public SupplierController(SupplierRepo<Supplier> supplierRepo) 
        {
            this.supplierRepo = supplierRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSuppliers()
        {
            return Ok(await supplierRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSupplierById(int id)
        {
            return Ok(await supplierRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            try
            {
                await supplierRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
