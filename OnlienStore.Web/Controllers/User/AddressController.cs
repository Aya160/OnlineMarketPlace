using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.AppAccouting;
using OnlineStore.Infrastructure.Repository.Users;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressRepo<Address> addressRepo;

        public AddressController(AddressRepo<Address> addressRepo) 
        {
            this.addressRepo = addressRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAddress()
        {
            return Ok(await addressRepo.GetAllAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAddressById(int id)
        {
            return Ok(await addressRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            try
            {
                await addressRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
