using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.DTO.Master
{
    public class CityDto : BaseDto<CityDto, City>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappingsInverse()
               .Map(dest => dest.Id, src => src.CityId)
               .Map(dest => dest.Name, src => src.CityName)
               .Map(dest => dest.Url, src => src.CityUrl);
        }
    }
}
