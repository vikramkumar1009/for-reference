using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class CompanyInsertDto : BaseDto<CompanyInsertDto, CompanyInsert>
    {
        public string CompanyName { get; set; }
        public string Username { get; set; }
        public string CPassword { get; set; }
        public string ContactPersonName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string KeyAM_Name { get; set; }
        public string KeyAM_Mobile { get; set; }
        public string KeyAM_Email { get; set; }
        public string CompanyDomain { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyLogo { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.VCompanyName,
                     src => src.CompanyName);



            SetCustomMappingsInverse()
                .Map(dest => dest.CompanyName, src => src.VCompanyName);
         }
    }
}
