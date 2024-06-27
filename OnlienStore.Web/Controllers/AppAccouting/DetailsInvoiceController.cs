using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Web.DTOs.AppAccountingDTO;
using OnlineStore.Web.DTOs.ShippingDTO;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsInvoiceController : ControllerBase
    {
        private readonly DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo;

        public DetailsInvoiceController(DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo) 
        {
            this.detailsInvoiceRepo = detailsInvoiceRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllDetailsInvoices()
        {
            return Ok(await detailsInvoiceRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetailsInvoiceById(int id)
        {
            return Ok(await detailsInvoiceRepo.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<DetailsInvoiceDTO>> CreateShippingCompaniesPermissions(DetailsInvoiceDTO detailsInvoiceDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            DetailsInvoice detailsInvoice = new()
            {
                PayCash = detailsInvoiceDTO.PayCash,
                Postpaid = detailsInvoiceDTO.Postpaid,
                DueDate = detailsInvoiceDTO.DueDate,
            };
            await detailsInvoiceRepo.CreateAsync(detailsInvoice);
            string uri = Url.Action(nameof(GetDetailsInvoiceById), new { id = detailsInvoice.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DetailsInvoiceDTO>> UpdateShippingCompanies(int id, DetailsInvoiceDTO detailsInvoiceDTO)
        {
            var detailsInvoice = await detailsInvoiceRepo.GetById(id);
            if (detailsInvoice is null) return NotFound(new ApiResponse(404));
            detailsInvoice.PayCash = detailsInvoiceDTO.PayCash;
            detailsInvoice.Postpaid = detailsInvoiceDTO.Postpaid;
            detailsInvoice.DueDate = detailsInvoiceDTO.DueDate;
            await detailsInvoiceRepo.UpdateAsync(id, detailsInvoice);
            return Ok(detailsInvoice);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDetailsInvoice(int id)
        {
            try
            {
                await detailsInvoiceRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
