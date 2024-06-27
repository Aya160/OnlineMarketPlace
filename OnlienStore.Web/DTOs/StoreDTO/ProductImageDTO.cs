namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class ProductImageDTO
    {
        public int ImageId { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }//name
    }
}
