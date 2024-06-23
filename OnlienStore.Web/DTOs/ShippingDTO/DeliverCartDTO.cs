using OnlineStore.Web.DTOs.StoreDTO;
using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.DTOs.ShippingDTO
{
    public class DeliverCartDTO
    {

        public string DeliverLocation { get; set; }
        public DateOnly DateArrival { get; set; }
        public int? OrderId { get; set; }
        public OrderDTO Order { get; set; } //name
        public int? AddersId { get; set; }
        public AddressDTO Address { get; set; }
        public int? CompanyId { get; set; }
        public ShippingCompaniesDTO Company { get; set; }
    }
}
