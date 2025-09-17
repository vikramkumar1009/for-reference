using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain
{
    public interface IInvoiceService
    {
        Task<InvoiceInfo> InsertInvoice(InvoiceInsert invoice);
    }
}
