using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.NRLHealth;
using System.Text.Json.Serialization;

namespace Dlplone.LMS.DTO.NRLHealth
{
    public class NRLFileDto : BaseDto<NRLFileDto, NRLFileDetail>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public DateTime? Date { get; set; }
        public string? Doctor { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Assignee { get; set; }
        public int CommentsCount { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                 .Map(dest => dest.FileName,
                     src => src.Name)
                .Map(dest => dest.AssignedTo,
                     src => src.Assignee)
                .Map(dest => dest.CreatedDate,
                     src => src.Date)
             .Map(dest => dest.FilePath,
                     src => src.Path);
               


            SetCustomMappingsInverse()
                .Map(dest => dest.Name,
                     src => src.FileName)
                .Map(dest => dest.Assignee,
                     src => src.AssignedTo)
                .Map(dest => dest.Date,
                     src => src.CreatedDate)
                .Map(dest => dest.Path,
                     src => src.FilePath);

        }
    }
}
