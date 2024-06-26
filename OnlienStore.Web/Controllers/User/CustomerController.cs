using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;

namespace OnlineStore.Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepo<Customer> customerRepo;

        public CustomerController(CustomerRepo<Customer> customerRepo) 
        {
            this.customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            return Ok(await customerRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomerById(int id)
        {
            return Ok(await customerRepo.GetById(id));
        }
    }
}
