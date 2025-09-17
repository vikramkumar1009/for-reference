using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dlplone.LMS.DTO.Infrastructure
{
    public class Token
    {
        [Key]
        [JsonIgnore]
        public Guid GuidId
        {
            get;
            set;
        }
        [JsonIgnore]
        public DateTime? ExpiredTime
        {
            get;
            set;
        }

        [JsonIgnore]
        public bool IsInvalid
        {
            get;
            set;
        }
    }
}
