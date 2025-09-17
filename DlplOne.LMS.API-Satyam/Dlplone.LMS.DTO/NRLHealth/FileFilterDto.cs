using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlplone.LMS.DTO.NRLHealth
{
    public class FileFilterDto : FilterDto
    {
        public DateTime? Date  { get; set; }
        public string? DoctorEmail { get; set; }
    }
}
