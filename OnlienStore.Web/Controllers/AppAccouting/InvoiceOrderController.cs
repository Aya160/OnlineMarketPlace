using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Web.ErrorHandeling;

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceOrder(int id)
        {
            try
            {
                await invoiceOrderRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
