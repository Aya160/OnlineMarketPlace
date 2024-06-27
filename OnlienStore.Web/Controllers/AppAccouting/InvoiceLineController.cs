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
        [HttpPost]
        public async Task<ActionResult<InvoiceLineDTO>> CreateInvoiceLine(InvoiceLineDTO invoiceLineDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            InvoiceLine invoiceLine = new()
            {
                Price = invoiceLineDTO.Price,
                Quantity = invoiceLineDTO.Quantity,
            };
            await invoiceLineRepo.CreateAsync(invoiceLine);
            string uri = Url.Action(nameof(GetInvoiceLineById), new { id = invoiceLine.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<InvoiceLineDTO>> UpdateInvoiceLine(int id, InvoiceLineDTO invoiceLineDTO)
        {
            var invoiceLine = await invoiceLineRepo.GetById(id);
            if (invoiceLine is null) return NotFound(new ApiResponse(404));
            invoiceLine.Price = invoiceLineDTO.Price;
            invoiceLine.Quantity = invoiceLineDTO.Quantity;
            await invoiceLineRepo.UpdateAsync(id, invoiceLine);
            return Ok(invoiceLine);
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
