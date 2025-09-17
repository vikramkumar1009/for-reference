using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class CompanyUpdateDto : BaseDto<CompanyUpdateDto, CompanyUpdate>
    {
        public int CompanyId { get; set; }
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
        public bool BlockFurtherReports { get; set; }
        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.VCompanyName,
                     src => src.CompanyName)
                .Map(dest => dest.CId,
                     src => src.CompanyId);



            SetCustomMappingsInverse()
                .Map(dest => dest.CompanyName, src => src.VCompanyName)
                .Map(dest => dest.CompanyId, src => src.CId);
        }
    }
}
