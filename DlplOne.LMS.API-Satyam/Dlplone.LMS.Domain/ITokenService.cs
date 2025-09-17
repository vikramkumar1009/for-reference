using Dlplone.LMS.DTO.Infrastructure;

namespace Dlplone.LMS.Domain
{
    public interface ITokenService
    {
        UserToken GenToken(UserToken model);
    }
}
