using OnlineStore.Web.DTOs.StoreDTO;

namespace OnlineStore.Web.DTOs.AppAccountingDTO
{
    public class InvoiceOrderLineDTO
    {
        public int InvoiceOrderLineId { get; set; }
        public int Quantity { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int? InvoiceOrderId { get; set; }
        public InvoiceOrderDTO InvoiceOrder { get; set; }
    }
}
