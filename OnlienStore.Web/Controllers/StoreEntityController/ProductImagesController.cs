using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Web.DTOs.StoreDTO;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers.StoreEntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController(ProductImageRepo<ProductImage> _imageRepo, ProductRepo<Product> _productRepo, IWebHostEnvironment _environment) : ControllerBase
    {
        readonly ProductImageRepo<ProductImage> imageRepo = _imageRepo;
        readonly ProductRepo<Product> productRepo = _productRepo;
         readonly IWebHostEnvironment environment = _environment;

        [HttpGet]
        public async Task<ActionResult> GetAllImages()
        {
            return Ok(await imageRepo.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetImageById(int id)
        {
            var image = await imageRepo.GetById(id);
            if (image == null) return NotFound(new ApiResponse(404));
            return Ok(image);
        }
        [HttpPost]
        public async Task<ActionResult<ProductImageDTO>> CreateImage([FromForm] ProductImageDTO imageDTO)
        {
            if (imageDTO.Image == null || imageDTO.Image.Length <= 0)
                return BadRequest(new ApiResponse(400,"Image file is required."));

            var product = await productRepo.GetById((int)imageDTO.ProductId);

            if (product == null) return NotFound(new ApiResponse(404,"Can't find this product"));

            var image = new ProductImage
            {
                ProductId = imageDTO.ProductId
            };

            // Save the image file to the server
            image.Image = await SaveImageAndGetPath(imageDTO.Image);

           await imageRepo.CreateAsync(image);

            var createdImageDTO = MapImageToDTO(image);
            return CreatedAtAction(nameof(GetImageById), new { id = image.Id}, createdImageDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(int id, [FromForm] ProductImageDTO imageDTO)
        {
            if (id != imageDTO.ImageId) return BadRequest("ImageId in the URL does not match the one in the request body.");

            if (imageDTO.Image == null || imageDTO.Image.Length <= 0)
            {
                return BadRequest("Image file is required.");
            }
            var image = await imageRepo.GetById(id);

            if (image == null)
                return NotFound();

            var product = await productRepo.GetById((int)imageDTO.ProductId);

            if (product == null)
                return BadRequest("Invalid ProductId.");

            // Delete the old image file from the server if necessary
            if (!string.IsNullOrEmpty(image.Image))
            {
                DeleteImageFile(image.Image);
            }

            // Save the new image file to the server
            image.Image = await SaveImageAndGetPath(imageDTO.Image);
            image.ProductId = imageDTO.ProductId;

            await imageRepo.UpdateAsync(id, image);
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var image = await imageRepo.GetById(id);

            if (image is null) return NotFound();

            // Delete the image file from the server
            if (!string.IsNullOrEmpty(image.Image))
                DeleteImageFile(image.Image);

           await imageRepo.DeleteAsync(id);
            return Ok("Deleted Succsessfully");
        }
        private ProductImageDTO MapImageToDTO(ProductImage image)
        {
            return new ProductImageDTO
            {
                ImageId = image.Id,
                ImageUrl = image.Image,
                ProductId = image.ProductId,
                ProductName = image.Product.Name,
            };
        }
        private ProductDTO MapProductToDTO(Product product)
        {
            return new ProductDTO
            {
                 Name= product.Name,
                 Price= product.Price,
                 SaleProductId= product.SaleProductId,
            };
        }
        private async Task<string> SaveImageAndGetPath(IFormFile image)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(environment.WebRootPath,"Images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
            return filePath;
        }
         void DeleteImageFile(string filePath)
            {
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
            }
        }
}
