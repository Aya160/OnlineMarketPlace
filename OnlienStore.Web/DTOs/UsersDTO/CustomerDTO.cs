using OnlineStore.Core.Entities.Users;

namespace OnlineStore.Web.DTOs.UsersDTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Image { get; set; }
        public int? AccountId { get; set; }
        public AccountDTO Account { get; set; }
    }
}
