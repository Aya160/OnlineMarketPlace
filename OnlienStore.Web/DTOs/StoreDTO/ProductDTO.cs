
namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public ICollection<ProductImageDTO> Images { get; set; }
    }
}
