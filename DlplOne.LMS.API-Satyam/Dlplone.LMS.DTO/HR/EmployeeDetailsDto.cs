using Dlplone.LMS.DTO.Infrastructure;
using Dlplone.LMS.Entities.HR;
using System.ComponentModel.DataAnnotations;

namespace Dlplone.LMS.DTO.HR
{
    public class EmployeeDetailsDto : BaseDto<EmployeeDetailsDto, EmployeeDetails>
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee Name cannot be empty!")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string EmpName { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email ID is not valid!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee Email cannot be empty!")]
        public string EmpEmail { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Employee Id cannot be empty!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Empid is not valid!")]
        public string EmpId { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile is not valid!")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Mobile cannot be empty!")]
        public string EmpMobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "UserId cannot be empty!")]
        public string UserId { get; set; }

        //[RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,1500}$", ErrorMessage = "special characters are not allowed.")]
        //public dynamic Comments { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "EId is not valid!")]
        public int EId { get; set; }
        public bool SendReport { get; set; }

        public bool SoftCopy { get; set; }
        public bool HardCopy { get; set; }
        public string TestPanel { get; set; }
        public string LabLocationId { get; set; }

        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.employeeid,
                     src => src.EId)
                .Map(dest => dest.TestPanelId,
                     src => src.TestPanel);


            SetCustomMappingsInverse()
                .Map(dest => dest.EId, src => src.employeeid)
                .Map(dest => dest.TestPanel, src => src.TestPanelId);
        }
    }
}
