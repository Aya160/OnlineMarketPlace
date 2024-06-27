using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.DTOs.StoreDTO;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleProductController : ControllerBase
    {
        public SaleProductRepo<SaleProduct> saleProductRepo { get; }
        public SaleProductController(SaleProductRepo<SaleProduct> saleProductRepo)
        {
            this.saleProductRepo = saleProductRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllSaleProducts()
        {
            return Ok(await saleProductRepo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSaleProductById(int id)
        {
            return Ok(await saleProductRepo.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<SaleProductDTO>> CreateSaleProduct(SaleProductDTO saleProductDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            SaleProduct saleProduct = new()
            {
                StartSale = saleProductDTO.StartSale,
                EndSale = saleProductDTO.EndSale,
                Discount = saleProductDTO.Discount,
            };
            await saleProductRepo.CreateAsync(saleProduct);
            string uri = Url.Action(nameof(GetSaleProductById), new { id = saleProduct.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SaleProductDTO>> UpdateSaleProduct(int id, SaleProductDTO saleProductDTO)
        {
            var saleProduct = await saleProductRepo.GetById(id);
            if (saleProduct is null) return NotFound(new ApiResponse(404));
            saleProduct.StartSale = saleProductDTO.StartSale;
            saleProduct.EndSale = saleProductDTO.EndSale;
            saleProduct.Discount = saleProductDTO.Discount;
            await saleProductRepo.UpdateAsync(id, saleProduct);
            return Ok(saleProduct);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSaleProduct(int id)
        {
            try
            {
                await saleProductRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
