using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly AdministratorRepo<Administrator> administratorRepo;

        public AdministratorController(AdministratorRepo<Administrator> administratorRepo) 
        {
            this.administratorRepo = administratorRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAdministrators()
        {
            return Ok(await administratorRepo.GetAllAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAdministratorById(int id)
        {
            return Ok(await administratorRepo.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdministrator(int id)
        {
            try
            {
                await administratorRepo.DeleteAsync(id);
            }
            catch (Exception)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
        }
    }
}
