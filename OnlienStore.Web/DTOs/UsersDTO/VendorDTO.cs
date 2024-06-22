namespace OnlineStore.Web.DTOs.UsersDTO
{
    public class VendorDTO
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public decimal Salary { get; set; }
        public int? AccountId { get; set; }
        public AccountDTO Account { get; set; }
    }
}
