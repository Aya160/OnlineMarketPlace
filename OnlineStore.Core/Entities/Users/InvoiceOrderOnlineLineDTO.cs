using OnlineStore.Web.DTOs.StoreDTO;

namespace OnlineStore.Web.DTOs.AppAccountingDTO
{
    public class InvoiceOrderOnlineLineDTO
    {
        public int InvoiceOrderOnlineLineId { get; set; }
        public int Quantity { get; set; }
        public int? OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
