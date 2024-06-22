namespace OnlineStore.Web.DTOs.ShippingDTO
{
    public class ShippingCompaniesDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNO { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public ICollection<ShippingCompaniesPermissionsDTO> ShippingCompaniesPermissions { get; set; }
    }
}
