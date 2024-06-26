using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

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
    }
}
