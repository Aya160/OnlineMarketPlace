using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

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
    }
}
