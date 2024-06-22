namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class SaleProductDTO
    {
        public int SaleProductId { get; set; }
        public DateOnly StartSela { get; set; }
        public DateOnly EndSela { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
