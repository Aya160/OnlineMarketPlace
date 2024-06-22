namespace OnlineStore.Web.DTOs.AppAccountingDTO
{
    public class InvoiceOrderDTO
    {
        public int InvoiceOrderId { get; set; }
        public bool CashPayment { get; set; }
        public bool OnlinePayment { get; set; }
        public int Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public DateOnly CreateDate { get; set; }
        public List<InvoiceOrderLineDTO> InvoiceOrderLines { get; set; }
    }
}
