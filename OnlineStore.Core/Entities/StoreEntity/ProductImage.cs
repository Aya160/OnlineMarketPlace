using Microsoft.AspNetCore.Http;
using OnlineStore.Core.Entities.General;

namespace OnlineStore.Core.Entities.StoreEntity
{
    public class ProductImage : BaseEntity
    {
        public IFormFile Image {  get; set; }
        public string ImageUrl {  get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
