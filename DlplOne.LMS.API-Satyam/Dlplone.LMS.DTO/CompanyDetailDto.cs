using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlplone.LMS.DTO
{
    public class CompanyDetailDto : BaseDto<CompanyDetailDto, CompanyDetail>
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string CPassword { get; set; }
        public string ContactPersonName { get; set; }
        public string MobileNumber { get; set; }
        public string KeyAM_Name { get; set; }
        public string KeyAM_Mobile { get; set; }
        public string KeyAM_Email { get; set; }
        public string CompanyDomain { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyLogo { get; set; }
        public bool BlockFurtherReports { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.CId,
                     src => src.CompanyId)
                .Map(dest => dest.ContactPersonName,
                     src => src.ContactPerson);


            SetCustomMappingsInverse()
                .Map(dest => dest.CompanyId, src => src.CId)
                .Map(dest => dest.ContactPerson, src => src.ContactPersonName);

        }
    }

}