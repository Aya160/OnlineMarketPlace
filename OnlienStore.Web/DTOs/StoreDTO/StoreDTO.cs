using OnlineStore.Web.DTOs.UsersDTO;

namespace OnlineStore.Web.DTOs.StoreDTO
{
    public class StoreDTO
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? AdressId { get; set; }
        public AddressDTO Address { get; set; }
        public StoreManagerDTO StoreManager { get; set; }
        public List<SaleProductDTO> SaleProducts { get; set; }
        public List<SaleCategoryDTO> SaleCategories { get; set; }

    }
}
