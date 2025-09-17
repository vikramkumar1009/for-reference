using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Dlplone.LMS.Domain.Tokens;

namespace Dlplone.LMS.Infrastructure
{
    public class LPLTokenVerify : ActionFilterAttribute
    {
        private readonly ITokenRepository tokenRepository;
        public LPLTokenVerify(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var guid = context.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == "guid")?.Value??"";
            var userType = context.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == "UserType")?.Value??"";
            var xuv = context.HttpContext.Request.Cookies["XUV"];
            var isInvalid = tokenRepository.IsInvalid(guid).Result;
            if (!xuv?.Contains(userType)??false || isInvalid)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

