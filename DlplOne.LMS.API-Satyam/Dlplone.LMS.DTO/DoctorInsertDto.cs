using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class DoctorInsertDto : BaseDto<DoctorInsertDto, DoctorInsert>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int UserType { get; set; }
        public string UserFor
        {
            get
            {
                return UserType == 1 ? "For Doctor Certificate" : "For Radiology Reports";
            }
        }


        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.VEnterName,
                     src => src.Name)
                .Map(dest => dest.VEnterEmailId,
                     src => src.Email)
            .Map(dest => dest.VEnterPassword,
                     src => src.Password)
            .Map(dest => dest.VSType,
                     src => src.UserFor)
                .Map(dest => dest.VSValue,
                     src => src.UserType);
        }
    }
}
