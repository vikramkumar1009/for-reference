using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace Dlplone.LMS.Domain.Infrastructure
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<CommunicationService> logger;
        public CommunicationService(IConfiguration _configuration, ILogger<CommunicationService> _logger)
        {
            configuration = _configuration;
            logger = _logger;
        }
        public async Task<string> SendMyMailOctane(string sFromWho, string sToWho, string sSubject, string sEmailBody, string sBcc, string sCC, string replyTo)
        {
            string SMTP_USERNAME = string.Format(configuration["MailSettings:SMTP_USERNAME"].ToString());
            string SMTP_PASSWORD = string.Format(configuration["MailSettings:SMTP_PASSWORD"].ToString());
            string HOST = string.Format(configuration["MailSettings:HOST"].ToString());
            const int PORT = 2587;

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("Dr Lal PathLabs<noreply@lalpathlabs.com>", sToWho);
            message.Body = sEmailBody;

            if (sBcc != "")
            {
                message.Bcc.Add(sBcc);
            }

            if (sCC != "")
            {
                message.CC.Add(sCC);
            }

            if (replyTo != string.Empty)
            {
                message.ReplyToList.Add(replyTo);
            }

            message.Subject = sSubject;

            message.IsBodyHtml = true;


            using (SmtpClient client = new SmtpClient(HOST, PORT))
            {
                client.Credentials = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
                client.EnableSsl = true;
                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    ServicePointManager.DefaultConnectionLimit = 9999;
                    await client.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    SendMyMail(sFromWho, sToWho, sSubject, sEmailBody, sBcc, sCC);
                }
            }
            return "";
        }

        public async Task<string> SendMyMail(string sFromWho, string sToWho, string sSubject, string sEmailBody, string sBcc, string sCC)
        {
            MailMessage oMail = new MailMessage(string.Format(configuration["MailSettings:SendMyMail"]), sToWho, sSubject, sEmailBody);
            oMail.CC.Add(sCC);
            oMail.Subject = sSubject;
            oMail.Body = sEmailBody;
            oMail.Bcc.Add(sBcc);
            oMail.IsBodyHtml = true;
            string SMTP_USERNAME = string.Format(configuration["MailSettings:SMTP_USERNAME"].ToString());
            string SMTP_PASSWORD = string.Format(configuration["MailSettings:SMTP_PASSWORD"].ToString());
            string HOST = string.Format(configuration["MailSettings:HOST"].ToString());
            const int PORT = 2587;
            using (SmtpClient client = new SmtpClient(HOST, PORT))
            {
                client.Credentials = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
                client.EnableSsl = true;
                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    ServicePointManager.DefaultConnectionLimit = 9999;
                    await client.SendMailAsync(oMail);
                }
                catch (Exception ex)
                {
                    await SendMyMail(sFromWho, sToWho, sSubject, sEmailBody, sBcc, sCC);
                }
            }
            return "";

        }

    }
}
