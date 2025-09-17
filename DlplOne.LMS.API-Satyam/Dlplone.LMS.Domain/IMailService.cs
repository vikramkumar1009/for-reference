using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain
{
    public interface IMailService
    {
        Task<string> SendMail(int id);
        Task<string> SendMailToEmployee(PreEmpProgress preEmpProgress, int id);
    }
}
