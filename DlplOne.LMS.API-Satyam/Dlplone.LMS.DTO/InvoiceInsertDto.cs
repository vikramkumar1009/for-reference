using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class InvoiceInsertDto : BaseDto<InvoiceInsertDto,InvoiceInsert>
    {
        public int CompanyId { get; set; }
        public string? InvoiceCode { get; set; }
        public string? MoU { get; set; }
        public string? AccountType { get; set; }
        public string? IsPrimaryInvcode { get; set; }
        public DateTime? MoUExpiryDate { get; set; }
        public string? TestPanelCode { get; set; }
        public string? OtherInfo { get; set; }
        public string? BannerImage { get; set; }
        public string? BannerImageLink { get; set; }
        public string? Itype { get; set; }
        public string? Pretest { get; set; }
        public string? PretestOther { get; set; }
        public string? PatientEmailId { get; set; }
        public string? DoccOnProcess { get; set; }
        public string? PanelCode { get; set; }
        public string? CustomerType { get; set; }
        public string? LabLocation { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.VCId,
                     src => src.CompanyId)
                .Map(dest => dest.VInvoiceCode,
                     src => src.InvoiceCode)
                .Map(dest => dest.VIsPrimaryInvcode,
                     src => src.IsPrimaryInvcode)
                .Map(dest => dest.VAccountType,
                     src => src.AccountType)
                .Map(dest => dest.VPretest,
                     src => src.Pretest)
                .Map(dest => dest.VBannerImage,
                     src => src.BannerImage)
                .Map(dest => dest.VDoccOnProcess,
                     src => src.DoccOnProcess)
                .Map(dest => dest.VTestPanelCode,
                     src => src.TestPanelCode)
                .Map(dest => dest.VPretestOther,
                     src => src.PretestOther)
                .Map(dest => dest.VItype,
                     src => src.Itype)
                .Map(dest => dest.VMoU,
                     src => src.MoU)
                .Map(dest => dest.VPatientEmailId,
                     src => src.PatientEmailId)
                .Map(dest => dest.VOtherInfo,
                     src => src.OtherInfo)
                .Map(dest => dest.VBannerImageLink,
                     src => src.BannerImageLink);
        }
    }
}
