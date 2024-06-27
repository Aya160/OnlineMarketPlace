namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class SaleCategoryDTO
    {
        public int SaleCategoryId {  get; set; }
        public DateOnly StartSale { get; set; }
        public DateOnly EndSale { get; set; }
        public int Discount { get; set; }
        //public List<CategoryDTO> Categories { get; set; }
    }
}
