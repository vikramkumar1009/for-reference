using Dlplone.LMS.Entities;
using Dlplone.LMS.Entities.Infrastructure;
using Dlplone.LMS.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlplone.LMS.Domain
{
   
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies(Filter filter);
        Task<int> AddCompany(CompanyInsert company);
        Task<int> UpdateCompany(CompanyUpdate company);
        Task<int> DeleteCompany(int companyId);
        Task<string> DecryptPassword(string password);
        Task<IEnumerable<TestPanelCode>> GetPanelCodes(string userId, string invoiceCode);
        Task<CompanyDetail> GetCompanyDetail(int id);
    }
}
