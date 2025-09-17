using Microsoft.Extensions.Logging;
using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain.Implementation
{
    public class TestPanelService : ITestPanelService
    {
        private readonly IPartnerRepository repository;
        private readonly ILogger<TestPanelService> logger;
        public TestPanelService(IPartnerRepository _repository, ILogger<TestPanelService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }
        public async Task<string> AddTestPanel(TestPanel testPanel)
        {
            try
            {
                testPanel.Flag = "I";
                var res = await repository.ExecuteRawSqlAsync<string, TestPanel>(nameof(PROCS.SaveTestPanelCode), testPanel, false);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> UpdateTestPanel(int id, TestPanel testPanel)
        {
            try
            {
                testPanel.Id = id;
                testPanel.Flag = "U";
                var res = await repository.ExecuteRawSqlAsync<string, object>(nameof(PROCS.SaveTestPanelCode), testPanel, false);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TestPanel>> GetTestPanels()
        {
            try
            {

                var res = await repository.ExecuteRawSqlAsync<TestPanel, int?>(nameof(PROCS.GetTestPanelCode), null, false);
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
