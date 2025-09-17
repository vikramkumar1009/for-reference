using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.DTO.Master
{
    public class TestPanelCodeDto : BaseDto<TestPanelCodeDto, TestPanelCode>
    {

        public string? Key { get; set; }
        public string? Value { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappingsInverse()
               .Map(dest => dest.Key, src => src.Text)
               .Map(dest => dest.Value, src => src.Value);
        }
    }
}
