using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.HR;
using Dlplone.LMS.Entities.Master;

namespace Dlplone.LMS.DTO.HR
{
    public class EmpDetailsDto : BaseDto<EmpDetailsDto, EmpDetails>
    {
        public int EId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpId { get; set; }
        public string EmpMobile { get; set; }
        public string EmpComments { get; set; }
        public string Emailstatus { get; set; }
        public bool SendReport { get; set; }

        public bool SoftCopy { get; set; }

        public bool HardCopy { get; set; }
        public List<int> TestPanels { get; set; }

        public int LabLocationId { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.Id,
                     src => src.EId);


            SetCustomMappingsInverse()
                .Map(dest => dest.EId, src => src.Id);
        }
    }


    public class PartnerEmpList
    {
        public string UserId { get; set; }
        public List<EmpDetailsDto> EmpDetails { get; set; }
    }
}
