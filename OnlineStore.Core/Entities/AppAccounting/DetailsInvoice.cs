﻿using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.AppAccounting
{
    public class DetailsInvoice : BaseEntity
    {
        public int PayCash { get; set; }
        public int Postpaid { get; set; }
        public DateOnly DueDate { get; set; }
        public int? InvoiceId { get; set; }
        public PurchaseBill PurchaseBill { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
