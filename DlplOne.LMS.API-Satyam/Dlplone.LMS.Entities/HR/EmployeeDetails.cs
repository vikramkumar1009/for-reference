using System.ComponentModel.DataAnnotations;

namespace Dlplone.LMS.Entities.HR
{
    public class EmployeeDetails
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
        public int employeeid { get; set; }
        public string flag { get; set; }
        public bool SendReport { get; set; }

        public string SoftCopy { get; set; }
        public string HardCopy { get; set; }
        public string TestPanelId { get; set; }
        public string LabLocationId { get; set; }
    }
}
