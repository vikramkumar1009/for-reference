using Dlplone.LMS.DTO.Infrastructure;


namespace Dlplone.LMS.DTO
{
    public class DocumentDto : BaseDto<DocumentDto, Entities.Document>
    {

        public int LabNumber { get; set; }
        public string? FilePath { get; set; }
        public DateTime? SubmissionDate { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.Files,
                     src => src.FilePath)
                .Map(dest => dest.LabNo,
                     src => src.LabNumber)
                .Map(dest => dest.EntryDate,
                     src => src.SubmissionDate);
  


            SetCustomMappingsInverse()
                .Map(dest => dest.FilePath, src => src.Files)
                .Map(dest => dest.LabNumber, src => src.LabNo)
                .Map(dest => dest.SubmissionDate, src => src.EntryDate);
        }
    }
}
