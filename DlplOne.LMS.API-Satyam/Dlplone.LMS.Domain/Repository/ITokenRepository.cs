using Microsoft.EntityFrameworkCore;
using Dlplone.LMS.DTO.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlplone.LMS.Domain.Tokens
{
    public interface ITokenRepository
    {
        Task<Token> AddToken(UserToken userToken);

        Task<int> InvalidateToken(string token);

        Task<bool> IsInvalid(string token);
    }
}
