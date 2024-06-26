using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceOrderOnlineLineController : ControllerBase
    {
        private readonly InvoiceOrderOnlineLineRepo<InvoiceOrderOnlineLine> invoiceOrderOnlineLineRepo;

        public InvoiceOrderOnlineLineController(InvoiceOrderOnlineLineRepo<InvoiceOrderOnlineLine> invoiceOrderOnlineLineRepo) 
        {
            this.invoiceOrderOnlineLineRepo = invoiceOrderOnlineLineRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInvoiceOrderOnlineLines()
        {
            return Ok(await invoiceOrderOnlineLineRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceOrderOnlineLineById(int id)
        {
            return Ok(await invoiceOrderOnlineLineRepo.GetById(id));
        }
    }
}
