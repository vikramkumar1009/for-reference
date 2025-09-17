using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using Dlplone.LMS.DTO;
using Dlplone.LMS.DTO.Master;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "3")]
    public class CompanyController : ControllerBase
    {
        private readonly  ICompanyService companyService;
        private readonly ILogger<CompanyController> logger;
        public CompanyController(ICompanyService _companyService, ILogger<CompanyController> _logger)
        {
                companyService = _companyService;
                logger = _logger;
        }


        [HttpPost("list")]
        public async Task<IActionResult> GetCompanies(FilterDto filterDto)
        {
            var filter = filterDto.ToEntity();
            var companies = await companyService.GetCompanies(filter);
            var dtos = CompanyDto.FromEntities(companies);
            return  Ok(dtos);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = await companyService.GetCompanyDetail(id);
            var comDto =  CompanyDetailDto.FromEntity(company);
            return  Ok(comDto);
        }
        
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] CompanyInsertDto company)
        {
            var comapanyEntity = company.ToEntity();
            var inserted = await companyService.AddCompany(comapanyEntity);
            return  Ok(inserted);
        }
        
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] CompanyUpdateDto company)
        {
            var comapanyEntity = company.ToEntity();
            var updated = await companyService.UpdateCompany(comapanyEntity);
            return  Ok(updated);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await companyService.DeleteCompany(id);
            return  Ok(deleted);
        }

        [HttpGet("panels/{invoiceCode}")]
        public async Task<IActionResult> GetPanelCodes(string invoiceCode)
        {

            var panelentities  = await companyService.GetPanelCodes(null, invoiceCode);
            var panelDtos = TestPanelCodeDto.FromEntities(panelentities);
            return Ok(panelDtos);
        }

        [HttpGet("pass/{pass}")]
        public async Task<IActionResult> GetPlainPass(string pass)
        {
            var deleted = await companyService.DecryptPassword(pass);
            return Ok(deleted);
        }
    }
}
