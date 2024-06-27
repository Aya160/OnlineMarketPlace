namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class SaleProductDTO
    {
        public int SaleProductId { get; set; }
        public DateOnly StartSale { get; set; }
        public DateOnly EndSale { get; set; }
        public int Discount { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
