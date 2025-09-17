using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.DTO.Master
{
    public class LabLocationInfoDto  : BaseDto<LabLocationInfoDto, LabLocation>
    {
        public int LocId { get; set; }
        public string? CenterLocation { get; set; }
        public string? CenterName { get; set; }
        public string? CenterAddress { get; set; }
        public string? CenterState { get; set; }
        public string? CenterCity { get; set; }
        public string? CenterContact { get; set; }
        public string? CenterEmail { get; set; }
        public string? Latitudes { get; set; }
        public string? Longitudes { get; set; }
        public string? GroupMailId { get; set; }
    }
}
