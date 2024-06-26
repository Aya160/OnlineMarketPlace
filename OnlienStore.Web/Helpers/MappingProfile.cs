using AutoMapper;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Web.DTOs.AppAccountingDTO;
using OnlineStore.Web.DTOs.StoreDTO;
using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Customer, CustomerDTO>();
            // CreateMap<Category, CategoryDTO>().ForMember(c => c.SaleCategorie.Discount, DTO => DTO.MapFrom(c => c.SaleCategory.Discount));

            CreateMap<Category, CategoryDTO>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
       .ForMember(dest => dest.SaleCategorie, opt => opt.MapFrom(src => src.SaleCategory));

            CreateMap<Product, ProductDTO>();

            CreateMap<SaleCategory, SaleCategoryDTO>();
        }
    }
}
