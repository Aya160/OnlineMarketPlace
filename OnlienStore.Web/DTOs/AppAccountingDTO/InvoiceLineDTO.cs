using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Web.DTOs.StoreDTO;

namespace OnlineStore.Web.DTOs.AppAccountingDTO
{
    public class InvoiceLineDTO
    {
        public int InvoiceLineId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? InvoiceId { get; set; }
        public PurchaseBillDTO PurchaseBill { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
