using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;
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
