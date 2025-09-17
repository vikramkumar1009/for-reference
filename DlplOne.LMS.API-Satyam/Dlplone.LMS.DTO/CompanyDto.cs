using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class CompanyDto : BaseDto<CompanyDto, Company>
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.CId,
                     src => src.CompanyId)
                .Map(dest => dest.ContactPersonName,
                     src => src.ContactPerson);


            SetCustomMappingsInverse()
                .Map(dest => dest.CompanyId, src => src.CId)
                .Map(dest => dest.ContactPerson, src => src.ContactPersonName);
        }
    }
}
