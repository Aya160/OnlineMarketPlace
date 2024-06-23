using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Web.DTOs.UsersDTO
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PhoneNO1 { get; set; }
        public string PhoneNO2 { get; set; }
        public Address Address { get; set; }

    }
}
