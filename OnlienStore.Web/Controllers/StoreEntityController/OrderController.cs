using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepo<Order> orderRepo;

        public OrderController(OrderRepo<Order> orderRepo) 
        {
            this.orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            return Ok(await orderRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrdertById(int id)
        {
            return Ok(await orderRepo.GetById(id));
        }
    }
}
