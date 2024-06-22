namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class StoreManagerPermissionsDTO
    {
        public int PermissionId { get; set; }
        public string Permission { get; set; }
        public string PermissionStatus { get; set; }
        public int? StoreManagerId { get; set; }
        public StoreManagerDTO StoreManager { get; set; }
    }
}
