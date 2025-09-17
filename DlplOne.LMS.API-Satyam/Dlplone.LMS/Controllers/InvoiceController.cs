using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using Dlplone.LMS.DTO;
using System.Data;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "1,2")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        private readonly ILogger<InvoiceController> logger;
        public InvoiceController(IInvoiceService _invoiceService, ILogger<InvoiceController> _logger)
        {
            invoiceService = _invoiceService;
            this.logger = _logger;

        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceInsertDto invoce)
        {

            var invoceEntity = invoce.ToEntity();
            var invoceinfo = await invoiceService.InsertInvoice(invoceEntity);
            var invoceDto =  InvoiceInfoDto.FromEntity(invoceinfo);
            return Ok(invoceDto);
        }



    }
}
