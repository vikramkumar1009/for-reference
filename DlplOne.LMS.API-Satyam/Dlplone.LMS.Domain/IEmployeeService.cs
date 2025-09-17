using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain
{
    public interface IEmployeeService
    {
        Task<int> SavePreEmploymentEmpDetails(string invoice, int companyId, int employeeId);
        Task<PreEmpInfo> GetPreEmpDetails(string invoice, int companyId, string guid);
        Task<int> SaveIntoPreEmploymentProgress(PreEmpProgress preEmpProgress);
        Task<PreEmpReport> GetReportDetails(string invoice, int companyId, string eid);
        Task<int> UpdatePreEmploymentEmpDetails(int empId, string accountType);
    }
}
