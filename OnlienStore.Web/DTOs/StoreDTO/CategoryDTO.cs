using OnlineStore.Core.Entities.StoreEntity;

namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
