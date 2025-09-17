using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Entities;
using System.Text;
using System;
using Microsoft.Extensions.Logging;

namespace Dlplone.LMS.Domain.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository repository;
        private readonly ILogger<EmployeeService> logger;
        public EmployeeService(IPartnerRepository _repository,
               ILogger<EmployeeService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }
        public async Task<int> SavePreEmploymentEmpDetails(string invoice, int companyId, int employeeId)
        {
            try
            {
                var result = await repository.ExecuteRawSqlAsync<int, object>(nameof(PROCS.UDSP_LPL_PARTNER_GET_UPDATE_PRE_EMPLOYEES), new { INVOICECODE = invoice, EmpId = employeeId, CId = companyId, flag = "P" }, false);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> SaveIntoPreEmploymentProgress(PreEmpProgress preEmpProgress)
        {
            try
            {
                string decryptedGuid = DecryptGuid(preEmpProgress.Guid);
                preEmpProgress.Guid = decryptedGuid;
                var result = await repository.ExecuteRawSqlAsync<int, PreEmpProgress>(nameof(PROCS.UDSP_LPL_Pre_employment_Progress), preEmpProgress, false);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> UpdatePreEmploymentEmpDetails(int empId, string accountType)
        {
            try
            {
                var result = await repository.ExecuteRawSqlAsync<int, object>(nameof(PROCS.UDSP_LPL_PARTNER_GET_UPDATE_PRE_EMPLOYEES), new { EmpId = empId, AccountType = accountType, flag = "u" }, false);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PreEmpInfo> GetPreEmpDetails(string invoice, int companyId, string guid)
        {
            try
            {
                string decryptedGuid = DecryptGuid(guid);
                var data = await repository.ExecuteRawSqlAsync<PreEmpInfo, ExpiryDetails, int, object>(nameof(PROCS.UDSP_LPL_PARTNER_GET_UPDATE_PRE_EMPLOYEES),
                    new { INVOICECODE = invoice, decryptguid = decryptedGuid, CId = companyId, flag = "s" }, false);
                var empInfo = ((IEnumerable<PreEmpInfo>)data[0])?.FirstOrDefault();
                var expriry = ((IEnumerable<ExpiryDetails>)data[1])?.FirstOrDefault();
                if (empInfo != null && expriry != null)
                {
                    empInfo.Guid = expriry.Guid;
                    empInfo.Dt = expriry.Dt;
                }
                return empInfo;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PreEmpReport> GetReportDetails(string invoice, int companyId, string eid)
        {
            try
            {

                var data = await repository.ExecuteRawSqlAsync<PreEmpReport, Report, int, object>(nameof(PROCS.UDSP_LPL_PARTNER_GET_UPDATE_PRE_EMPLOYEES),
                    new { INVOICECODE = invoice, eid = eid, CId = companyId, flag = "p" }, false);
                var empReport = ((IEnumerable<PreEmpReport>)data[0])?.FirstOrDefault();
                var report = ((IEnumerable<Report>)data[1])?.FirstOrDefault();
                int labId = ((IEnumerable<int>)data[3]).FirstOrDefault();

                if (empReport != null && report != null)
                {
                    empReport.SendReport = report.SendReport;
                    empReport.SoftCopy = report.SoftCopy;
                    empReport.HardCopy = report.HardCopy;
                }
                empReport.LabLocation = labId;
                return empReport;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string DecryptGuid(string guid)
        {
            string decrypt = string.Empty;
            Decoder Decode = new UTF8Encoding().GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(guid);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decrypt = new String(decoded_char);
            return decrypt;
        }
    }
}
