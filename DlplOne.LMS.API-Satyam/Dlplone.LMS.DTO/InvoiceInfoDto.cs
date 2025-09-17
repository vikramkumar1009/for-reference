using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class InvoiceInfoDto : BaseDto<InvoiceInfoDto, InvoiceInfo>
    {
        public int InvId { get; set; }
        public int CompanyId { get; set; }
        public string? InvoiceCode { get; set; }
        public string? TestPanelCode { get; set; }
        public string? OtherInfo { get; set; }
        public string? BannerImage { get; set; }
        public string? BannerImageLink { get; set; }
        public string? MoU { get; set; }
        public string? AccountType { get; set; }
        public string? IsPrimaryInvCode { get; set; }
        public string? MoUExpiryDate { get; set; }
        public string? Itype { get; set; }
        public string? Pretest { get; set; }
        public string? Pretestother { get; set; }
        public string? Patientemailid { get; set; }
        public string? DoccOnProcess { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappingsInverse()
                .Map(dest => dest.CompanyId, src => src.CId);

        }
    }
}
