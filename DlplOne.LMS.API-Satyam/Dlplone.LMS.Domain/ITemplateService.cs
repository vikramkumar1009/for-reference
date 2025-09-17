using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain
{
    public interface ITemplateService
    {
        Task<Templates> GetTemplateAsync(int id);
    }
}
