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
    public class SaleCategoryController : ControllerBase
    {
        public SaleCategoryRepo<SaleCategory> saleCategoryRepo { get; }
        public SaleCategoryController(SaleCategoryRepo<SaleCategory> saleCategoryRepo)
        {
            this.saleCategoryRepo = saleCategoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetSaleCategoriesAll()
        {
            return Ok(await saleCategoryRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSaleCategoryById(int id)
        {
            return Ok(await saleCategoryRepo.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<SaleCategoryDTO>> CreateSaleCategory(SaleCategoryDTO saleCategoryDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            SaleCategory saleCategory = new()
            {
                StartSale = saleCategoryDTO.StartSale,
                EndSale = saleCategoryDTO.EndSale,
                Discount = saleCategoryDTO.Discount,
            };
            await saleCategoryRepo.CreateAsync(saleCategory);
            string uri = Url.Action(nameof(GetSaleCategoryById), new { id = saleCategory.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SaleCategoryDTO>> UpdateSaleCategory(int id, SaleCategoryDTO saleCategoryDTO)
        {
            var saleCategory = await saleCategoryRepo.GetById(id);
            if (saleCategory is null) return NotFound(new ApiResponse(404));
            saleCategory.StartSale = saleCategoryDTO.StartSale;
            saleCategory.EndSale = saleCategoryDTO.EndSale;
            saleCategory.Discount = saleCategoryDTO.Discount;
            await saleCategoryRepo.UpdateAsync(id, saleCategory);
            return Ok(saleCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSaleCategory(int id)
        {
            try
            {
                await saleCategoryRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
