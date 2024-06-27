using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Web.DTOs.AppAccountingDTO;
using OnlineStore.Web.ErrorHandeling;

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
        [HttpPost]
        public async Task<ActionResult<InvoiceOrderOnlineLineDTO>> CreateInvoiceOrderOnlineLine(InvoiceOrderOnlineLineDTO invoiceOrderOnlineLineDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            InvoiceOrderOnlineLine invoiceOrderOnlineLine = new()
            {
                Quantity = invoiceOrderOnlineLineDTO.Quantity,
            };
            await invoiceOrderOnlineLineRepo.CreateAsync(invoiceOrderOnlineLine);
            string uri = Url.Action(nameof(GetInvoiceOrderOnlineLineById), new { id = invoiceOrderOnlineLine.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceOrderOnlineLineDTO>> UpdateInvoiceOrderOnlineLine(int id, InvoiceOrderOnlineLineDTO invoiceOrderOnlineLineDTO)
        {
            var invoiceOrderOnlineLine = await invoiceOrderOnlineLineRepo.GetById(id);
            if (invoiceOrderOnlineLine is null) return NotFound(new ApiResponse(404));
            invoiceOrderOnlineLine.Quantity = invoiceOrderOnlineLineDTO.Quantity;
            await invoiceOrderOnlineLineRepo.UpdateAsync(id, invoiceOrderOnlineLine);
            return Ok(invoiceOrderOnlineLine);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceOrderOnlineLine(int id)
        {
            try
            {
                await invoiceOrderOnlineLineRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
