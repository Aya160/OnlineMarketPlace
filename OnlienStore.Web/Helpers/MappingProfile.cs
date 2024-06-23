using AutoMapper;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Web.DTOs.AppAccountingDTO;

namespace OnlineStore.Web.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DetailsInvoice, DetailsInvoiceDTO>();
        }
    }
}
