using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

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
    }
}
