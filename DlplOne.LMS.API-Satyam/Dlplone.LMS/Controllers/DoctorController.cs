using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using Dlplone.LMS.DTO;
using Dlplone.LMS.DTO.Infrastructure.Validators;
using Dlplone.LMS.Entities;
using System.Data;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "3")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        private readonly ILogger<DoctorController> logger;
        public DoctorController(IDoctorService _doctorService, ILogger<DoctorController> _logger)
        {
            doctorService = _doctorService;
            this.logger = _logger;
        }


        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] DoctorInsertDto doctor)
        {

            var validateDoctor = new DoctorValidator();
            var result = validateDoctor.Validate(doctor);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));
            }
            var doctorEntity = doctor.ToEntity();
            var res = await doctorService.DoctorSignUp(doctorEntity);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> Doctors()
        {
  
            var res = await doctorService.Doctors();
            var dtos = DoctorDto.FromEntities(res);
            return Ok(dtos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {

            var res = await doctorService.DeleteDoctor(id);
            return Ok(res);
        }
    }
}
