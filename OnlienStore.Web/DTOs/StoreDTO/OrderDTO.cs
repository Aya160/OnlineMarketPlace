using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime RequstDate { get; set; }
        public int? CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
        public List<ContaintProduct> ContaintProducts { get; set; }
        public DeliverCart DeliverCart { get; set; }
    }
}
