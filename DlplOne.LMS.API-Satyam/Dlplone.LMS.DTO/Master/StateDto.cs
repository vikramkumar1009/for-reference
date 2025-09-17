using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.DTO.Master
{
    public class StateDto : BaseDto<StateDto,State>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        public override void AddCustomMappings()
        {
             SetCustomMappingsInverse()
                .Map(dest => dest.Id, src => src.StateId)
                .Map(dest => dest.Name, src => src.StateName)
                .Map(dest => dest.Url, src => src.StateUrl);
        }
    }
}
