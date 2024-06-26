namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class SaleCategoryDTO
    {
        public int SaleCategoryId {  get; set; }
        public DateOnly StartSela { get; set; }
        public DateOnly EndSela { get; set; }
        public int Discount { get; set; }
        //public List<CategoryDTO> Categories { get; set; }
    }
}
