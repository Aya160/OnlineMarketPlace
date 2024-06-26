using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Infrastructure.Repository.Shipping;

namespace OnlineStore.Web.Controllers.Shipping
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverCartController : ControllerBase
    {
        private readonly DeliverCartRepo<DeliverCart> deliverCartRepo;

        public DeliverCartController(DeliverCartRepo<DeliverCart> deliverCartRepo) 
        {
            this.deliverCartRepo = deliverCartRepo;
        }

    }
}
