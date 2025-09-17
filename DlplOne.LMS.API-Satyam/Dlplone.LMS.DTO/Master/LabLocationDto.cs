using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.DTO.Master
{
    public class LabLocationDto :  BaseDto<LabLocationDto, LabLocation>
    {
        public string? Key { get; set; }
        public string? Value { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappingsInverse()
               .Map(dest => dest.Key, src => src.CenterLocation)
               .Map(dest => dest.Value, src => src.LocId);
        }
    }
}
