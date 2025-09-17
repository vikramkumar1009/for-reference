using AspNetCoreRateLimit;
using Dlplone.LMS.Domain;
using Dlplone.LMS.Domain.Implementation;
using Dlplone.LMS.Domain.Infrastructure;
using Dlplone.LMS.Domain.Tokens;
using Serilog.Core;

namespace Dlplone.LMS.Infrastructure
{
    public static class InjectableServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddTransient<ICryptography, Cryptography>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<ICommunicationService, CommunicationService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IFindCenterService, FindCenterService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITestPanelService, TestPanelService>();
            services.AddScoped<IHttpService, HttpService>();
   
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<LPLTokenVerify>();
            services.AddScoped<TokenContext>();
            services.AddSqlServerRepositorySingleton<IPartnerRepository,Repository>("LocalDb");
           
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.ClientIdHeader = "X-ClientId";
                options.GeneralRules = new List<RateLimitRule>
        {
            new RateLimitRule
            {
                Endpoint = "POST:/api/Login/nrl",
                Period = "1h",
                Limit = 4,
            }
        };
            });
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            services.AddInMemoryRateLimiting();
            return services;
        }
    }
}
