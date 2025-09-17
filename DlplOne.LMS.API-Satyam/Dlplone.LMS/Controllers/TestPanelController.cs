using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using Dlplone.LMS.DTO;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestPanelController : ControllerBase
    {
        private readonly ITestPanelService testPanelService;
        private readonly ILogger<TestPanelController> logger;
        public TestPanelController(ITestPanelService _testPanelService, ILogger<TestPanelController> _logger)
        {
                testPanelService = _testPanelService;
                this.logger = _logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddTestPanel([FromBody]TestPanelDto testPanel)
        {
            var panel = testPanel.ToEntity();
            var res = await testPanelService.AddTestPanel(panel);
            return Ok(res);
        }
        
        
        [HttpPost("edit/{id}")]
        public async Task<IActionResult> AddTestPanel(int id,[FromBody]TestPanelDto testPanel)
        {
            var panel = testPanel.ToEntity();
            var res = await testPanelService.UpdateTestPanel(id,panel);
            return Ok(res);
        }
        
        
        [HttpGet("list")]
        public async Task<IActionResult> GetTestPanels()
        {
           
            var res = await testPanelService.GetTestPanels();
            var dtos = TestPanelDto.FromEntities(res);
            return Ok(res);
        }
    }
}
