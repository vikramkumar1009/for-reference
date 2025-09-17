using Microsoft.Extensions.Logging;
using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Domain.Tokens;
using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService tokenservice;
        private readonly IPartnerRepository repository;
        private readonly INRLHealthRepository nRLHealthRepository;
        private readonly ICryptography cryptography;
        private readonly ITokenRepository tokenRepository;
        private readonly ILogger<LoginService> logger;
        public LoginService(ITokenService _tokenservice, IPartnerRepository _repository,
            INRLHealthRepository nRLHealthRepository, ICryptography _cryptography,
            ITokenRepository tokenRepository,
            ILogger<LoginService> _logger)
        {

            tokenservice = _tokenservice;
            this.repository = _repository;
            this.nRLHealthRepository = nRLHealthRepository;
            this.cryptography = _cryptography;
            this.logger = _logger;
            this.tokenRepository = tokenRepository;
        }
        public async Task<UserToken> UserLogin(Login login)
        {

            var result = await repository.ExecuteRawSqlAsync<int, Login>(nameof(PROCS.UDSP_PARTNER_ADMINLOGIN), login, false);
            var token = tokenservice.GenToken(new UserToken
            {
                EmailId = login.VUsername,
                UserName = login.VUsername,
                GuidId = Guid.NewGuid(),
                UserType = result.FirstOrDefault()
            });
            return await Task.FromResult(token);
        }

        public async Task<UserToken> NRLUserLogin(Login login)
        {

            login.VCPassword = cryptography.Encrypt(login.VCPassword);
            var result = await nRLHealthRepository.ExecuteRawSqlAsync<int, Login>(nameof(PROCS.NRL_USER_LOGIN), login, false);
            var user = result.FirstOrDefault();
            if (user > 0)
            {
                var token = tokenservice.GenToken(new UserToken
                {
                    EmailId = login.VUsername,
                    UserName = login.VUsername,
                    UserType = result.FirstOrDefault()
                });
                await tokenRepository.AddToken(token);
                return await Task.FromResult(token);
            }
            else
                return null;
        }
    }
}
