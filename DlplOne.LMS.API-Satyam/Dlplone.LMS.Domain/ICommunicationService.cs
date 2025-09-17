namespace Dlplone.LMS.Domain
{
    public interface ICommunicationService
    {
        Task<string> SendMyMailOctane(string sFromWho, string sToWho, string sSubject, string sEmailBody, string sBcc, string sCC, string replyTo);
        Task<string> SendMyMail(string sFromWho, string sToWho, string sSubject, string sEmailBody, string sBcc, string sCC);
    }
}
