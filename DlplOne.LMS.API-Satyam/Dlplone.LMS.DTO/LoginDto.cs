using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class LoginDto : BaseDto<LoginDto, Login>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.VUsername,
                     src => src.Username)
                .Map(dest => dest.VCPassword,
                     src => src.Password);


            SetCustomMappingsInverse()
                .Map(dest => dest.Username, src => src.VUsername)
                .Map(dest => dest.Password, src => src.VCPassword);
        }
    }
}
