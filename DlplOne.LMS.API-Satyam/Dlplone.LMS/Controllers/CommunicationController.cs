using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using System.Data;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "3")]
    public class CommunicationController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly ILogger<CommunicationController> logger;
        public CommunicationController(IMailService _mailService, ILogger<CommunicationController> _logger)
        {
            mailService = _mailService;   
            logger = _logger;
        }
        [HttpGet("email/doctor/{id}")]
        public async Task<IActionResult> SendMailToDoctor(int id)
        {

            var result = await mailService.SendMail(id);
            return Ok(result);
        }
        
        [HttpGet("email/employee/{id}")]
        public async Task<IActionResult> SendMailToEmployee(int id)
        {

            //var result = await mailService.SendMailToEmployee(id);
            return Ok();
        }
    }
}
