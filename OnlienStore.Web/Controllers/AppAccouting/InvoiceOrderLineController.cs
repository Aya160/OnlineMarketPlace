using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceOrderLineController : ControllerBase
    {
        private readonly InvoiceOrderLineRepo<InvoiceOrderLine> invoiceOrderLineRepo;

        public InvoiceOrderLineController(InvoiceOrderLineRepo<InvoiceOrderLine> invoiceOrderLineRepo) 
        {
            this.invoiceOrderLineRepo = invoiceOrderLineRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInvoiceOrderLines()
        {
            return Ok(await invoiceOrderLineRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceOrderLineById(int id)
        {
            return Ok(await invoiceOrderLineRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceOrderLine(int id)
        {
            try
            {
                await invoiceOrderLineRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
