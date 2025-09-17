using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.DTO.Master
{
    public class AreaDto : BaseDto<AreaDto,Area>
    {
        public int AddressSequence { get; set; }
        public string? Location { get; set; }
        public string? Url { get; set; }


        public override void AddCustomMappings()
        {
            SetCustomMappingsInverse()
               .Map(dest => dest.AddressSequence, src => src.AddressSeq);
        }
    }
}
