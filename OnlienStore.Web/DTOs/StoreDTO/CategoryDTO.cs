namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
        public int? SaleCategoryId { get; set; }
        public SaleCategoryDTO SaleCategorie { get; set; }
    }
}
