using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Infrastructure;

namespace Dlplone.LMS.DTO
{
    public class FilterDto : BaseDto<FilterDto,Filter>
    {
        public int PageNo { get; set; } = 1;
        public int PageLength { get; set; } = 10;
        public string SortType { get; set; } = string.Empty;
        public string? SearchTerm { get; set; } 
    }
}
