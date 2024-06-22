using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class SaleProduct : BaseEntity
    {
        public DateOnly StartSela { get; set; }
        public DateOnly EndSela { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public ICollection<Product> Products { get; set;}
    }
}
