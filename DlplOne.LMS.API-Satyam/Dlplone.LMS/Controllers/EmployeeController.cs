using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using Dlplone.LMS.DTO;
using System.Text;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        private readonly IMailService mailService;
        private readonly ILogger<EmployeeController> logger;
        public EmployeeController(IEmployeeService _employeeService, IMailService _mailServive, ILogger<EmployeeController> _logger)
        {
            employeeService = _employeeService;
            mailService = _mailServive;
            logger = _logger;
        }


        [HttpGet("preemp/{inv}/{cid}/{guid}")]
        public async Task<IActionResult> GetPreEmplyeeDetails(string inv, int cid, string guid)
        {
            var empInfo = await employeeService.GetPreEmpDetails(inv, cid, guid);
            return Ok(empInfo);
        }


        [HttpPost("preemp/progress")]
        public async Task<IActionResult> GetPreEmplyeeDetails(PreEmpProgressDto preEmpProgress)
        {
            var preEmpEntitiy = preEmpProgress.ToEntity();
            var labLocation = await employeeService.SaveIntoPreEmploymentProgress(preEmpEntitiy);
            if (labLocation > 0)
            {
                var sent = mailService.SendMailToEmployee(preEmpEntitiy, labLocation);
            }

            return Ok(labLocation);
        }

        [HttpPost("preemp/update/{eid}/{accType}")]
        public async Task<IActionResult> UpdatePreEmplyeeDetails(int eid, string accType)
        {

            var res = await employeeService.UpdatePreEmploymentEmpDetails(eid, accType);
            return Ok(res);
        }
    }
}
