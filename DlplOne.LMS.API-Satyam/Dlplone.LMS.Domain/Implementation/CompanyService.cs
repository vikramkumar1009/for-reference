using Microsoft.Extensions.Logging;
using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Entities;
using Dlplone.LMS.Entities.Infrastructure;
using Dlplone.LMS.Entities.Master;
using System;

namespace Dlplone.LMS.Domain.Implementation
{
    public class CompanyService : ICompanyService
    {

        private readonly IPartnerRepository repository;
        private readonly ICryptography cryptography;
        private readonly ILogger<CompanyService> logger;
        public CompanyService(IPartnerRepository _repository, ICryptography _cryptography,
                ILogger<CompanyService> _logger)
        {
            repository = _repository;
            this.cryptography = _cryptography;
            this.logger = _logger;
        }

        public async Task<IEnumerable<Company>> GetCompanies(Filter filter)
        {
            try
            {
                var companies = await repository.ExecuteRawSqlAsync<Company,Filter>(nameof(PROCS.Get_LPL_PARTNER_COMPANY_DETAILS), filter, false);
                return companies;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task<CompanyDetail> GetCompanyDetail(int id)
        {
            try
            {
                var company = await repository.ExecuteRawSqlAsync<CompanyDetail,object>(nameof(PROCS.UDSP_PARTNER_COMPANY_RECORDS_DISPLAY),new { Vcid = id } , false);
                var c = company.FirstOrDefault();
                return c;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task<int> AddCompany(CompanyInsert company)
        {
            try
            {
                company.VCPassword = cryptography.Encrypt(company.VCPassword);
                var res = await repository.ExecuteRawSqlAsync<int,CompanyInsert>(nameof(PROCS.UDSP_PARTNER_COMPANYINFO), company, false);
                return res.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task<int> UpdateCompany(CompanyUpdate company)
        {
            try
            {
                await repository.ExecuteRawSqlAsync<int, CompanyUpdate>(nameof(PROCS.UDSP_PARTNER_COMPANYINFO_UPDATE), company, false);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        
        public async Task<int> DeleteCompany(int companyId)
        {
            try
            {
                await repository.ExecuteRawSqlAsync<int, object>(nameof(PROCS.UDSP_PARTNER_COMPANY_INVOICE_DELETE), new {varid = companyId,flag="C"}, false);
                return 1;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<TestPanelCode>> GetPanelCodes(string userId, string invoiceCode)
        {
            try
            {
                var panels = await repository.ExecuteRawSqlAsync<TestPanelCode, object>(nameof(PROCS.GET_COMPANY_TEST_PANEL_CODE), new {UserId = userId , Invoice = invoiceCode}, false);
                return panels;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<string> DecryptPassword(string password)
        {
            try
            {
                return cryptography.Decrypt(password);                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
