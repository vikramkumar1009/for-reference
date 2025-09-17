using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain
{
    public interface ILoginService
    {
        Task<UserToken> UserLogin(Login login);
        Task<UserToken> NRLUserLogin(Login login);
    }
}
