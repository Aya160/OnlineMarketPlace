using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Users;

namespace OnlineStore.Web.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorPermissionController : ControllerBase
    {
        private readonly AdministratorPermissionRepo<AdministratorPermission> administratorPermissionRepo;

        public AdministratorPermissionController(AdministratorPermissionRepo<AdministratorPermission> administratorPermissionRepo) 
        {
            this.administratorPermissionRepo = administratorPermissionRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAdministratorPermissions()
        {
            return Ok(await administratorPermissionRepo.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAdministratorPermissionById(int id)
        {
            return Ok(await administratorPermissionRepo.GetById(id));
        }
    }
}
