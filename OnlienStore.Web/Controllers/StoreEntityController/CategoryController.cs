using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.DTOs.StoreDTO;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
<<<<<<< HEAD
        public CategoryRepo<Category> categoryRepo { get; set; }

        public CategoryController(CategoryRepo<Category> _categoryRepo)
=======
         readonly Mapper mapper;
        public CategoryRepo<Category> categoryRepo { get; set; }
        public CategoryController(CategoryRepo<Category> categoryRepo)
>>>>>>> 3611270575ffeb090d82664f296d7c329cc6436c
        {
            this.categoryRepo = categoryRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var category = await categoryRepo.GetAllAsync();
            return Ok(category);
<<<<<<< HEAD

=======
>>>>>>> 3611270575ffeb090d82664f296d7c329cc6436c
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            return Ok(await categoryRepo.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            Category category = new()
            {
                Name = categoryDTO.Name,
            };
            await categoryRepo.CreateAsync(category);
            string uri = Url.Action(nameof(GetCategoryById), new { id = category.Id });
            return Created(uri, "Created Succsessfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            var category = await categoryRepo.GetById(id);
            if (category is null) return NotFound(new ApiResponse(404, $"Uneable to find {categoryDTO.Name} Category"));
            category.Name = categoryDTO.Name;
            await categoryRepo.UpdateAsync(id, category);
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                await categoryRepo.DeleteAsync(id);
            }
            catch (Exception)
            {

                return NotFound(new ApiResponse(404));
            }
            return Ok("Deleted Succsessfully");
<<<<<<< HEAD

=======
>>>>>>> 3611270575ffeb090d82664f296d7c329cc6436c
        }
    }
}
