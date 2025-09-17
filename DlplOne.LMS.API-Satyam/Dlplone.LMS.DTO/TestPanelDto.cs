using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;

namespace Dlplone.LMS.DTO
{
    public class TestPanelDto : BaseDto<TestPanelDto, TestPanel>
    {
        public int Id { get; set; }
        public string? TestPanelCode { get; set; }
        public string? TestPanelName { get; set; }
    }
}
