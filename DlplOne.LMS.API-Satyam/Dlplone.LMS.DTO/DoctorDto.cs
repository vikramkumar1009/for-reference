using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class DoctorDto : BaseDto<DoctorDto, Doctor>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public string? UserFor { get; set; }
        public int UserType { get; set; }

        public override void AddCustomMappings()
        {

            SetCustomMappingsInverse()
                .Map(dest => dest.Id, src => src.SId)
                .Map(dest => dest.Name, src => src.EnterName)
                .Map(dest => dest.EmailId, src => src.EnterEmailId)
                .Map(dest => dest.Password, src => src.EnterPassword)
                .Map(dest => dest.UserFor, src => src.SType)
                .Map(dest => dest.UserType, src => src.SValue);
        }
    }
}
