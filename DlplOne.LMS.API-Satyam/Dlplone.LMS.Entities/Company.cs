using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlplone.LMS.Entities
{
    public class Company
    {
        public int CId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string ContactPersonName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; }
    }
}
