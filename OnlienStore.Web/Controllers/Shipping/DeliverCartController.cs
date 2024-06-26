using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

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
    }
}
