namespace OnlineStore.Web.DTOs.ShippingDTO
{
    public class ShippingCompaniesPermissionsDTO
    {
        public int PermissionId { get; set; }
        public string Permission{ get; set; }
        public decimal DeliverPrice { get; set; }
        public int? CompanyId { get; set; }
        public ShippingCompaniesDTO ShippingCompanies { get; set; }
    }
}
