using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.Shipping
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCompaniesController : ControllerBase
    {
        private readonly ShippingCompaniesRepo<ShippingCompanies> shippingCompanies;

        public ShippingCompaniesController(ShippingCompaniesRepo<ShippingCompanies> shippingCompanies)
        {
            this.shippingCompanies = shippingCompanies;
        }
    }
}
