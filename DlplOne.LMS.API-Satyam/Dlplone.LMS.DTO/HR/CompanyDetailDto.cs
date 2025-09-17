using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.HR;

namespace Dlplone.LMS.DTO.HR
{
    public class CompanyDetailDto : BaseDto<CompanyDetailDto, CompanyDetail>
    {
        public string ComName { get; set; }
        public string ContactPersonName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string KeyAMName { get; set; }
        public string KeyAMMobile { get; set; }
        public string KeyAMEmail { get; set; }
        public string ComId { get; set; }
        public bool isForceRequired { get; set; }
        public string UserName { get; set; }
        public string UPassword { get; set; }
        public string InvoiceCode { get; set; }
        public string IsPrimaryInvCode { get; set; }
        public string MoUfile { get; set; }
        public string AccountType { get; set; }

        public string BannerImg { get; set; }
        public string BannerLink { get; set; }
        public string TestPanelCode { get; set; }
        public string Itype { get; set; }


        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.KeyAM_Name,
                     src => src.KeyAMName)
                .Map(dest => dest.KeyAM_Mobile,
                     src => src.KeyAMMobile)
                .Map(dest => dest.KeyAM_Email,
                     src => src.KeyAMEmail)
                .Map(dest => dest.CId,
                     src => src.ComId)
                .Map(dest => dest.MoU,
                     src => src.MoUfile)
                .Map(dest => dest.BannerImage,
                     src => src.BannerImg)
                .Map(dest => dest.BannerImageLink,
                     src => src.BannerLink)
                .Map(dest => dest.CompanyName,
                     src => src.ComName);


            SetCustomMappingsInverse()
                .Map(dest => dest.KeyAMName,
                     src => src.KeyAM_Name)
                .Map(dest => dest.KeyAMMobile,
                     src => src.KeyAM_Mobile)
                .Map(dest => dest.KeyAMEmail,
                     src => src.KeyAM_Email)
                .Map(dest => dest.ComId,
                     src => src.CId)
                .Map(dest => dest.MoUfile,
                     src => src.MoU)
                .Map(dest => dest.BannerImg,
                     src => src.BannerImage)
                .Map(dest => dest.BannerLink,
                     src => src.BannerImageLink)
                .Map(dest => dest.ComName,
                     src => src.CompanyName);
        }
    }
}
