using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class StoreManagerDTO
    {
        public int Manager {  get; set; }
        public DateTime StartAt { get; set; }
        public List<VendorDTO> vendors { get; set; }
        public List<StoreManagerPermissionsDTO> Permissions { get; set; }
    }
}
