using Microsoft.Extensions.Logging;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.Domain.Infrastructure
{
    public class MailService : IMailService
    {
	    private readonly ICommunicationService commService;
        private readonly IDoctorService doctorService;
        private readonly IFindCenterService findCenterService;
        private readonly ITemplateService templateService;
        private readonly ILogger<MailService> logger;
        public MailService(ICommunicationService communicationService, IDoctorService _doctorService, 
            ITemplateService _templateService, IFindCenterService findCenterService,
            ILogger<MailService> _logger)
        {
            commService = communicationService;
            doctorService = _doctorService;
            templateService = _templateService;
            this.findCenterService = findCenterService;
            logger = _logger;
        }
        public async  Task<string> SendMail(int id)
        {
			try
			{
                var doctor = await doctorService.Doctor(id);
                var template = await templateService.GetTemplateAsync(1);

                string toWho = "";
                string fromWho, mailSubject, mailError;
                string mailBcc, mailCc;
                toWho = doctor.EnterEmailId;
                fromWho = "";
                mailBcc = "ruchi@istrat.in";
                mailCc = "";
                mailSubject = "Login Details";
                string emailBody = string.Format(template.Template, doctor.EnterName, doctor.EnterEmailId, doctor.EnterPassword);
                var result = await commService.SendMyMailOctane(fromWho,toWho,mailSubject,emailBody,mailBcc,mailCc,string.Empty);
                return result;
			}
			catch (Exception ex)
			{

				throw;
			}
        }
        
        
        
        public async  Task<string> SendMailToEmployee(PreEmpProgress preEmpProgress, int id)
        {
			try
			{

                var area = await findCenterService.GetAreaDeatilsById(id);
                var template = await templateService.GetTemplateAsync(2);
                var OtherPreTestInfo = "op";
                var PreTestInfo = "t";
                var paymentType = "test";
                string toWho = "";
                string fromWho, mailSubject, mailError;
                string mailBcc, mailCc;

                toWho = preEmpProgress.VEmailID;
                fromWho = "";
                mailBcc = "mkprajapati0533@gmail.com";
                mailCc = "";
                mailSubject = "Test Details";
                string emailBody = string.Format(template.Template, area.CenterName,area.CenterAddress,area.CenterContact,preEmpProgress.VPreferredDate,
                    preEmpProgress.VPreferredSlot,preEmpProgress.VName,preEmpProgress.VGender,preEmpProgress.VDateofBirth,
                    preEmpProgress.VCity,area.CenterEmail,preEmpProgress.InvoiceCode,
                    "",preEmpProgress.TestPanelCode,area.Latitudes,area.Longitudes);
                if (OtherPreTestInfo != string.Empty)
                {
                    emailBody = emailBody.Replace("####pretest", @" <tr>
                <td style='padding:15px 15px 15px 15px; background-color:#ffffff; text-align:left; font-family:Arial, Helvetica, sans-serif; font-size:15px; color:#000000; border-bottom:1px solid #eaeaea; border-right:1px solid #eaeaea'>What do you need to do before the tests</td>
                <td style='padding:15px 15px 15px 15px; background-color:#ffffff; text-align:left; font-family:Arial, Helvetica, sans-serif; font-size:15px; color:#ff0000; border-bottom:1px solid #eaeaea; '><b>" + PreTestInfo + @", " + OtherPreTestInfo + @"</b></td>
                </tr>");
                }
                else
                {
                    if (PreTestInfo != string.Empty)
                    {
                        emailBody = emailBody.Replace("####pretest", @" <tr>
                        <td style='padding:15px 15px 15px 15px; background-color:#ffffff; text-align:left; font-family:Arial, Helvetica, sans-serif; font-size:15px; color:#000000; border-bottom:1px solid #eaeaea; border-right:1px solid #eaeaea'>What do you need to do before the tests</td>
                        <td style='padding:15px 15px 15px 15px; background-color:#ffffff; text-align:left; font-family:Arial, Helvetica, sans-serif; font-size:15px; color:#ff0000; border-bottom:1px solid #eaeaea; '><b>" + PreTestInfo + @"</b></td>
                        </tr>");
                    }
                }

                if (paymentType != string.Empty)
                {
                    emailBody = emailBody.Replace("####paymentType", @"<tr>
                                    <td style='padding:15px 15px 15px 15px; background-color:#ffffff; text-align:left; font-family:Arial, Helvetica, sans-serif; font-size:15px; color:#000000; border-bottom:1px solid #eaeaea; border-right:1px solid #eaeaea'>Payment Type</td>
                                     <td style='padding:15px 15px 15px 15px; background-color:#ffffff; text-align:left; font-family:Arial, Helvetica, sans-serif; font-size:13px; color:#ff0000; border-bottom:1px solid #eaeaea;'><b>" + paymentType + @"</b></td>
                                  </tr>");
                }
                var result = await commService.SendMyMailOctane(fromWho,toWho,mailSubject,emailBody,mailBcc,mailCc,string.Empty);
                return result;
			}
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
