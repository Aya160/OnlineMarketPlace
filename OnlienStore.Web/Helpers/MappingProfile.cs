using AutoMapper;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Web.DTOs.AppAccountingDTO;
using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
