namespace OnlineStore.Web.DTOs.UsersDTO
{
    public class AdministratorPermissionDTO
    {
        public string Permission { get; set; }
        public bool IsPermission { get; set; }
        public int? AdministratorId { get; set; }
        public string Administrator { get; set; }
    }
}
