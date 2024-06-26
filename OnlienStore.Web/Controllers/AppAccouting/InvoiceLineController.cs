using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceLineController : ControllerBase
    {
        private readonly InvoiceLineRepo<InvoiceLine> invoiceLineRepo;

        public InvoiceLineController(InvoiceLineRepo<InvoiceLine> invoiceLineRepo) 
        {
            this.invoiceLineRepo = invoiceLineRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInvoiceLines()
        {
            return Ok(await invoiceLineRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceLineById(int id)
        {
            return Ok(await invoiceLineRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceLine(int id)
        {
            try
            {
                await invoiceLineRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
