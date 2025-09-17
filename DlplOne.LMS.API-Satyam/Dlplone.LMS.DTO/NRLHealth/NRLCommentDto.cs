using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.NRLHealth;
using System.ComponentModel.DataAnnotations;

namespace Dlplone.LMS.DTO.NRLHealth
{
    public class NRLCommentDto : BaseDto<NRLCommentDto, NRLComment>
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int FileId { get; set; }
    }
}
