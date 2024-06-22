using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Web.DTOs.UsersDTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PhoneNO1 { get; set; }
        public string PhoneNO2 { get; set; }
        //public ICollection<PhoneNOForAccount> phoneNOs { get; set; }
        public int? AdressId { get; set; }
        public AddressDTO Address { get; set; }
        //public string Administrator { get; set; }
        //public Customer Customer { get; set; }
        //public Vendor Vendor { get; set; }
    }
}
