using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Web.DTOs.ShippingDTO;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.Shipping
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverCartController : ControllerBase
    {
        private readonly DeliverCartRepo<DeliverCart> deliverCartRepo;

        public DeliverCartController(DeliverCartRepo<DeliverCart> deliverCartRepo) 
        {
            this.deliverCartRepo = deliverCartRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDeliverCarts()
        {
            return Ok(await deliverCartRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeliverCartById(int id)
        {
            return Ok(await deliverCartRepo.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<DeliverCartDTO>> CreateDeliverCart(DeliverCartDTO deliverCartDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            DeliverCart deliverCart = new()
            {
                DeliverLocation = deliverCartDTO.DeliverLocation,
                DateArrival = deliverCartDTO.DateArrival,
            };
            await deliverCartRepo.CreateAsync(deliverCart);
            string uri = Url.Action(nameof(GetDeliverCartById), new { id = deliverCart.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliverCartDTO>> UpdateDeliverCart(int id, DeliverCartDTO deliverCartDTO)
        {
            var deliverCart = await deliverCartRepo.GetById(id);
            if (deliverCart is null) return NotFound(new ApiResponse(404));
            deliverCart.DeliverLocation = deliverCartDTO.DeliverLocation;
            deliverCart.DateArrival = deliverCartDTO.DateArrival;
            await deliverCartRepo.UpdateAsync(id, deliverCart);
            return Ok(deliverCart);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeliverCart(int id)
        {
            try
            {
                await deliverCartRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
