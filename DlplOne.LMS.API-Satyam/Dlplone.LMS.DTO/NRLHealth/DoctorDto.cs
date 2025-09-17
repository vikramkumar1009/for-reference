using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.NRLHealth;

namespace Dlplone.LMS.DTO.NRLHealth
{
    public class DoctorDto : BaseDto<DoctorDto, Doctor>
    {
        public int DoctorId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Password { get; set; }
        public int? UserType { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.Id,
                     src => src.DoctorId)
                .Map(dest => dest.EmailId,
                     src => src.Email)
                .Map(dest => dest.MobileNumber,
                     src => src.MobileNo);


            SetCustomMappingsInverse()
                .Map(dest => dest.DoctorId, src => src.Id)
                .Map(dest => dest.Email, src => src.EmailId)
                .Map(dest => dest.MobileNo, src => src.MobileNumber);
        }
    }
}
