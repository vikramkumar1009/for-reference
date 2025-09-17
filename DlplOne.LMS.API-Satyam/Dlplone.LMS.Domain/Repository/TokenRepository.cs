using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Dlplone.LMS.DTO.Infrastructure;

namespace Dlplone.LMS.Domain.Tokens
{
    public class TokenRepository : ITokenRepository
    {
        private readonly TokenContext tokenContext;
        public TokenRepository(TokenContext _tokenContext)
        {
            tokenContext = _tokenContext ?? throw new ArgumentNullException(nameof(tokenContext));
        }
        public async Task<Token> AddToken(UserToken userToken)
        {
            var memToken = new Token { GuidId = userToken.GuidId, IsInvalid = false, ExpiredTime = userToken.ExpiredTime };
            var token = await tokenContext.Tokens
                .AddAsync(memToken);
            tokenContext.SaveChanges();
          //  var tkns = new List<Token>();
          //  for (int i = 0; i < 100000; i++)
          //  {
          //      tkns.Add(memToken);
          //  }
          //var data =  JsonConvert.SerializeObject(tkns);
            return token.Entity;
        }

        public async Task<int> InvalidateToken(string token)
        {

            var t = await tokenContext.Tokens
                .FirstOrDefaultAsync(x => x.GuidId.ToString() == token);
            t.IsInvalid = true;
            tokenContext.Tokens.Update(t);
            await tokenContext.SaveChangesAsync();
            return 1;

        }

        public async Task<bool> IsInvalid(string token)
        {           
            await tokenContext.SaveChangesAsync();
            var t = await tokenContext.Tokens
                .FirstOrDefaultAsync(x => x.GuidId.ToString() == token);
            if(tokenContext.Tokens.Any(t => t.ExpiredTime < DateTime.UtcNow))
            {
                tokenContext.Tokens.RemoveRange(tokenContext.Tokens.Where(t => t.ExpiredTime < DateTime.UtcNow));
            }
            return t?.IsInvalid??true;
        }
    }
}

