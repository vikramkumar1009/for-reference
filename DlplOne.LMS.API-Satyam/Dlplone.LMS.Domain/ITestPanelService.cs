using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain
{
    public interface ITestPanelService
    {
        Task<string> AddTestPanel(TestPanel testPanel);
        Task<string> UpdateTestPanel(int id,TestPanel testPanel);
        Task<IEnumerable<TestPanel>> GetTestPanels();
    }
}
