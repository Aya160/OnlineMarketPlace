using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using System.Security.Claims;

namespace OnlineStore.Web.Controllers.StoreEntityControllers
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
        public async Task<ActionResult> GetAllOrder()
        {
            return Ok(await orderRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            return Ok(await orderRepo.GetById(id));
        }
    }
}
