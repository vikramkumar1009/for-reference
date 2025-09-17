using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.HR;

namespace Dlplone.LMS.DTO.HR
{

    public class ReportsResponseDto : BaseDto<ReportsResponseDto, ReportsResponse>
    {
        public int totalCount { get; set; }
        public List<Reports> list { get; set; }
    }

}
