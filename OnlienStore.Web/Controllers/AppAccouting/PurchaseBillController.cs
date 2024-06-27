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
    public class PurchaseBillController : ControllerBase
    {
        private readonly PurchaseBillRepo<PurchaseBill> purchaseBillRepo;

        public PurchaseBillController(PurchaseBillRepo<PurchaseBill> purchaseBillRepo) 
        {
            this.purchaseBillRepo = purchaseBillRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPurchaseBills()
        {
            return Ok(await purchaseBillRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPurchaseBillById(int id)
        {
            return Ok(await purchaseBillRepo.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<PurchaseBillDTO>> CreatePurchaseBill(PurchaseBillDTO purchaseBillDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            PurchaseBill purchaseBill = new()
            {
                InvoiceName = purchaseBillDTO.InvoiceName,
                CashPayment=purchaseBillDTO.IsCashPayment,
                CreditPayment=purchaseBillDTO.IsCreditPayment,
                //DateInvoice=purchaseBillDTO.DateInvoice,
                TotalAmount=purchaseBillDTO.TotalAmount,
                CreateDate=purchaseBillDTO.CreateDate,
            };
            await purchaseBillRepo.CreateAsync(purchaseBill);
            string uri = Url.Action(nameof(GetPurchaseBillById), new { id = purchaseBill.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseBillDTO>> UpdatePurchaseBill(int id, PurchaseBillDTO purchaseBillDTO)
        {
            var purchaseBill = await purchaseBillRepo.GetById(id);
            if (purchaseBill is null) return NotFound(new ApiResponse(404));
            
            await purchaseBillRepo.UpdateAsync(id, purchaseBill);
            return Ok(purchaseBill);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePurchaseBill(int id)
        {
            try
            {
                await purchaseBillRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
