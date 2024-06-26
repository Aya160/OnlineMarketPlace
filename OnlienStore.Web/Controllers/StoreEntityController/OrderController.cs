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
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            Order order = new()
            {
                RequstDate = DateTime.Now,
                CustomerId = orderDTO.CustomerId,
                ContaintProducts = orderDTO.ContaintProducts,
            };
            order.Customer = orderDTO.Customer;
            await orderRepo.CreateAsync(order);
            string uri = Url.Action(nameof(GetOrdertById), new { id = order.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(int id, OrderDTO orderDTO)
        {
           var order = await orderRepo.GetById(id);
            if (order is null) return NotFound(new ApiResponse(404, $"Uneable to find order"));
            order.Customer = orderDTO.Customer;
            order.ContaintProducts = orderDTO.ContaintProducts;
           await orderRepo.UpdateAsync(id, order);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                await orderRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
