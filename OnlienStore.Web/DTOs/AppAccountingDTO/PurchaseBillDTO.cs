namespace OnlineStore.Web.DTOs.AppAccountingDTO
{
    public class PurchaseBillDTO
    {
        public int InvoiceId { get; set; }
        public string InvoiceName { get; set; }
        public bool IsCashPayment { get; set; }
        public bool IsCreditPayment { get; set; }
        public DateOnly DateInvoice { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public DateOnly CreateDate { get; set; }
        public DetailsInvoiceDTO DetailsInvoice { get; set; }
        public List<InvoiceLineDTO> InvoiceLines { get; set; }
    }
}
