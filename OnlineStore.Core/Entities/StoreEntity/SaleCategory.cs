using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class SaleCategory : BaseEntity
    {
        public DateOnly StartSela { get; set; }
        public DateOnly EndSela { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
