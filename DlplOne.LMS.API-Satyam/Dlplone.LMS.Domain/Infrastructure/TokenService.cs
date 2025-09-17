using Microsoft.IdentityModel.Tokens;
using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Dlplone.LMS.Domain.Infrastructure
{
    public class TokenService : ITokenService
    {
        private readonly Jwt jwtSettings;
        public TokenService(Jwt _jwtSettings)
        {
            jwtSettings = _jwtSettings;       
        }
        public  IEnumerable<Claim> GetClaims(UserToken userAccounts, Guid Id)
            {
            IEnumerable<Claim> claims = new Claim[] {
                new Claim("UserType", userAccounts.UserType.ToString()),
                new Claim("add-token", userAccounts.XCubeToken),
                new Claim("guid", Id.ToString()),
                    new Claim(ClaimTypes.Name, userAccounts.UserName),
                    new Claim(ClaimTypes.Email, userAccounts.EmailId),
                    new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                    new Claim(ClaimTypes.Role, userAccounts.UserType.ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddMinutes(30).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };
                return claims;
            }
        public  IEnumerable<Claim> GetClaims(UserToken userAccounts, out Guid Id)
            {
                Id = Guid.NewGuid();
                return GetClaims(userAccounts, Id);
            }
        public  UserToken GenToken(UserToken model)
            {
                try
                {
                    var UserToken = new UserToken();
                    if (model == null) throw new ArgumentException(nameof(model));
                    // Get secret key
                    var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                    Guid Id = Guid.Empty;
                    DateTime expireTime = DateTime.UtcNow.AddMinutes(30);
                    UserToken.Validaty = expireTime.TimeOfDay;
                    var JWToken = new JwtSecurityToken(issuer: jwtSettings.ValidIssuer, 
                        audience: jwtSettings.ValidAudience, claims: GetClaims(model, out Id), 
                        notBefore: DateTime.UtcNow, 
                        expires: expireTime, 
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
                    UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                    //UserToken.UserName = model.UserName;
                    UserToken.UserType = model.UserType;
                    UserToken.ExpiredTime = expireTime;
                    UserToken.GuidId = Id;
                    //UserToken.GuidId = Id;
                    return UserToken;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
}
