using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.IRepository;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.DTOs.StoreDTO;

namespace OnlineStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryRepo<Category> CategoryRepo { get; }
        public CategoryController(CategoryRepo<Category> categoryRepo)
        {
            CategoryRepo = categoryRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            return Ok(await CategoryRepo.GetAllAsync());
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            return Ok(await CategoryRepo.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDTO categoryDTO)
        {
            Category category= new() {
                Name = categoryDTO.Name,

            };
           await CategoryRepo.CreateAsync(category);
            return Ok(category);
        }
    }
}
