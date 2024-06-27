using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Web.DTOs.AppAccountingDTO;
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
        public async Task<ActionResult<SupplierDTO>> CreateSupplier(SupplierDTO supplierDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            Supplier supplier = new()
            {
                SupplierName = supplierDTO.SupplierName,
                Email = supplierDTO.Email,
                PhoneNO = supplierDTO.PhoneNO,
                MaterialSupplied = supplierDTO.MaterialSupplied,
            };
            await supplierRepo.CreateAsync(supplier);
            string uri = Url.Action(nameof(GetSupplierById), new { id = supplier.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierDTO>> UpdateSupplier(int id, SupplierDTO supplierDTO)
        {
            var supplier = await supplierRepo.GetById(id);
            if (supplier is null) return NotFound(new ApiResponse(404));
            supplier.SupplierName = supplierDTO.SupplierName;
            supplier.Email = supplierDTO.Email;
            supplier.PhoneNO = supplierDTO.PhoneNO;
            supplier.MaterialSupplied = supplierDTO.MaterialSupplied;
            await supplierRepo.UpdateAsync(id, supplier);
            return Ok(supplier);
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
