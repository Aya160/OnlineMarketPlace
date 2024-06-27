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
        [HttpPost]
        public async Task<ActionResult<InvoiceOrderDTO>> CreateInvoiceOrder(InvoiceOrderDTO invoiceOrderDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            InvoiceOrder invoiceOrder = new()
            {
                CashPayment=invoiceOrderDTO.IsCashPayment,
                OnlinePayment=invoiceOrderDTO.IsOnlinePayment,
                Tax=invoiceOrderDTO.Tax,
                TotalAmount=invoiceOrderDTO.TotalAmount,
            };
            await invoiceOrderRepo.CreateAsync(invoiceOrder);
            string uri = Url.Action(nameof(GetInvoiceOrderById), new { id = invoiceOrder.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceOrderDTO>> UpdateInvoiceOrder(int id, InvoiceOrderDTO invoiceOrderDTO)
        {
            var invoiceOrder = await invoiceOrderRepo.GetById(id);
            if (invoiceOrder is null) return NotFound(new ApiResponse(404));
            invoiceOrder.CashPayment = invoiceOrderDTO.IsCashPayment;
            invoiceOrder.OnlinePayment = invoiceOrderDTO.IsOnlinePayment;
            invoiceOrder.Tax = invoiceOrderDTO.Tax;
            invoiceOrder.TotalAmount = invoiceOrderDTO.TotalAmount;
            await invoiceOrderRepo.UpdateAsync(id, invoiceOrder);
            return Ok(invoiceOrder);
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
