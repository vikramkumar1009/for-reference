using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dlplone.LMS.DTO.Infrastructure
{
    public class UserToken : Token
    {
        public string? Token
        {
            get;
            set;
        }

        public string? UserName
        {
            get;
            set;
        }
        [JsonIgnore]
        public TimeSpan Validaty
        {
            get;
            set;
        }
        [JsonIgnore]
        public string? RefreshToken
        {
            get;
            set;
        }
        [JsonIgnore]
        public int UserType
        {
            get;
            set;
        }
        [JsonIgnore]
        public string? EmailId
        {
            get;
            set;
        }
        [JsonIgnore]
        public string? XCubeToken
        {
            get;
            set;
        } = "Default";


    }
}
