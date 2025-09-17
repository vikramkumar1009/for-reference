using Microsoft.Extensions.Logging;
using Dlplone.LMS.Domain.Infrastructure.Enums;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain.Implementation
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IPartnerRepository repository;
        private readonly ILogger<InvoiceService> logger;
        public InvoiceService(IPartnerRepository _repository, ILogger<InvoiceService> _logger)
        {
            repository = _repository; 
            logger = _logger;
        }


        public async Task<InvoiceInfo> InsertInvoice(InvoiceInsert invoice)
        {
            try
            {
                var data = await repository.ExecuteRawSqlAsync<int, InvoiceInfo, int, int, int, int, int, InvoiceInsert>(nameof(PROCS.UDSP_PARTNER_COMPANY_INVOICEDETAILS), invoice, false);
                InvoiceInfo invoceInfo = ((IEnumerable<InvoiceInfo>)data[1]).FirstOrDefault();
                return invoceInfo;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
