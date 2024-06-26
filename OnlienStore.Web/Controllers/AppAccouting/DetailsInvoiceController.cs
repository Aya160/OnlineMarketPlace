using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Entities.AppAccounting;
using OnlineStore.Infrastructure.Repository.AppAccouting;

namespace OnlineStore.Web.Controllers.AppAccouting
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsInvoiceController : ControllerBase
    {
        private readonly DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo;

        public DetailsInvoiceController(DetailsInvoiceRepo<DetailsInvoice> detailsInvoiceRepo) 
        {
            this.detailsInvoiceRepo = detailsInvoiceRepo;
        }
    }
}
