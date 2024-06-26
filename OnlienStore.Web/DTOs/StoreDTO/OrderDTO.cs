using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Web.DTOs.ShippingDTO;
using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime RequstDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ContaintProduct> ContaintProducts { get; set; }
        public DeliverCartDTO DeliverCart { get; set; }
    }
}
