using OnlineStore.Core.Entities.AppAccounting;

namespace OnlineStore.Web.DTOs.AppAccountingDTO
{
    public class DetailsInvoiceDTO
    {
        public int DetailsInvoiceId { get; set; }
        public decimal PayCash { get; set; }
        public decimal Postpaid { get; set; }
        public DateOnly DueDate { get; set; }
        public int? InvoiceId { get; set; }
        public PurchaseBillDTO PurchaseBill { get; set; }
        public string SupplierName { get; set; }
    }
}
