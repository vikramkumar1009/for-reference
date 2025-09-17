using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using Dlplone.LMS.DTO.Master;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly IFindCenterService findCenterService;
        private readonly ILogger<CenterController> logger;
        public CenterController(IFindCenterService _findCenterService, ILogger<CenterController> _logger)
        {
            findCenterService = _findCenterService;   
            logger = _logger;
        }

        [HttpGet("states")]
        public async Task<IActionResult> GetStates()
        {
            var stateEntities = await findCenterService.GetStates();
            var states = StateDto.FromEntities(stateEntities);
            return Ok(states);    
        }
        
        [HttpGet("city/{stateurl}")]
        public async Task<IActionResult> GetCities(string stateurl)
        {
            var cityEntities = await findCenterService.GetCities(stateurl);
            var cities = CityDto.FromEntities(cityEntities);
            return Ok(cities);    
        }
        
        [HttpGet("area/{stateurl}/{cityurl}")]
        public async Task<IActionResult> GetAreas(string stateurl, string cityUrl)
        {
            var areaEntities = await findCenterService.GetAreas(stateurl, cityUrl);
            var areas = AreaDto.FromEntities(areaEntities);
            return Ok(areas);    
        }
        
        [HttpGet("lab/{labType}")]
        public async Task<IActionResult> GetLabLocations(string labType)
        {
            var labEntities = await findCenterService.GetLabs(labType);
            var locs = LabLocationDto.FromEntities(labEntities);
            return Ok(locs);    
        }
        [HttpGet("lab/location/{labId}")]
        public async Task<IActionResult> GetLocations(int labId)
        {
            var labEntity = await findCenterService.GetAreaDeatilsById(labId);
            var locs = LabLocationDto.FromEntity(labEntity);
            return Ok(locs);    
        }
    }
}
