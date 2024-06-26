using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class StoreManagerDTO
    {
        public int ManagerId {  get; set; }
        public DateTime StartAt { get; set; }
        public List<VendorDTO> Vendors { get; set; }
        public List<StoreManagerPermissionsDTO> Permissions { get; set; }
    }
}
