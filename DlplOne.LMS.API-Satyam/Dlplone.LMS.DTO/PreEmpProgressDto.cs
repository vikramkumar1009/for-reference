using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class PreEmpProgressDto : BaseDto<PreEmpProgressDto, PreEmpProgress>
    {
        public string? Name { get; set; }
        public string? EmailID { get; set; }
        public string? MobileNo { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? Gender { get; set; }
        public string? City { get; set; }
        public string? Locality { get; set; }
        public DateTime? PreferredDate { get; set; }
        public string? PreferredSlot { get; set; }
        public string? TestPanelCode { get; set; }
        public string? InvoiceCode { get; set; }
        public string? State { get; set; }
        public string? Guid { get; set; }
        public int LocationId { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.VName,
                     src => src.Name)
                .Map(dest => dest.VEmailID,
                     src => src.EmailID)
                .Map(dest => dest.VMobileNo,
                     src => src.MobileNo)
                .Map(dest => dest.VDateofBirth,
                     src => src.DateofBirth)
                .Map(dest => dest.VGender,
                     src => src.Gender)
                .Map(dest => dest.VPreferredDate,
                     src => src.PreferredDate)
                .Map(dest => dest.VPreferredSlot,
                     src => src.PreferredSlot)
                .Map(dest => dest.VLocality,
                     src => src.Locality);

        }
    }
}
