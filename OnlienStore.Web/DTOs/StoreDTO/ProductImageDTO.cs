namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class ProductImageDTO
    {
        public int ImageId { get; set; }
        public string Image { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
