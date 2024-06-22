namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class SelaCategoryDTO
    {
        public DateOnly StartSela { get; set; }
        public DateOnly EndSela { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
