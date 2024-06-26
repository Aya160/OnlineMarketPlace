using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsInvoiceController : ControllerBase
    {
        private readonly DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo;

        public DetailsInvoiceController(DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo) 
        {
            this.detailsInvoiceRepo = detailsInvoiceRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllDetailsInvoices()
        {
            return Ok(await detailsInvoiceRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetailsInvoiceById(int id)
        {
            return Ok(await detailsInvoiceRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDetailsInvoice(int id)
        {
            try
            {
                await detailsInvoiceRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
