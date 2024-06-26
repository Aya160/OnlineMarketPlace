using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceOrderController : ControllerBase
    {
        private readonly InvoiceOrderRepo<InvoiceOrder> invoiceOrderRepo;

        public InvoiceOrderController(InvoiceOrderRepo<InvoiceOrder> invoiceOrderRepo) 
        {
            this.invoiceOrderRepo = invoiceOrderRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllInvoiceOrders()
        {
            return Ok(await invoiceOrderRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceOrderById(int id)
        {
            return Ok(await invoiceOrderRepo.GetById(id));
        }
    }
}
