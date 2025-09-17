using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;
using Dlplone.LMS.Domain.Tokens;
using Dlplone.LMS.DTO;
using Dlplone.LMS.DTO.Infrastructure.Validators;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly ITokenRepository tokenRepository;
        private readonly ILogger<LoginController> logger;
        private readonly ICryptography cryptography;

        public LoginController(ILoginService _loginService, ILogger<LoginController> _logger,
            ICryptography _cryptography,
            ITokenRepository tokenRepository)
        {
            loginService = _loginService;
            logger = _logger;
            this.cryptography = _cryptography;
            this.tokenRepository = tokenRepository;
        }
        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDto login)
        {

                var validator = new LoginValidator();
                var valid = validator.Validate(login);
                if (valid.IsValid)
                {
                    var res = await loginService.UserLogin(login.ToEntity());
                    return Ok(res);
                }
                else
                {
                    return BadRequest(valid.Errors.Select(e => e.ErrorMessage));
                }
        }
        
        // POST api/<LoginController>
        [HttpGet("logout")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LogOut()
        {
            var tokenGuid = User?.Claims?.FirstOrDefault(x => x.Type == "guid")?.Value;
            await tokenRepository.InvalidateToken(tokenGuid);
            Response.Cookies.Delete("Authorization");
            Response.Cookies.Delete("XUV");
            return Ok();
        }
        
       

        [HttpGet("headers")]
        public IActionResult Header()
        {
            return Ok();
        }
    }
}
