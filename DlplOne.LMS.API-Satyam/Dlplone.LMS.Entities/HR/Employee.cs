using System.ComponentModel.DataAnnotations;

namespace Dlplone.LMS.Entities.HR
{
    public class Employee
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee Name cannot be empty!")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string EmpName { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email ID is not valid!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee Email cannot be empty!")]
        public string EmpEmail { get; set; }

        [RegularExpression("[0-9]+$", ErrorMessage = "Invalid Emp ID")]
        public string EmpId { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile is not valid!")]
        public string EmpMobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "UserId cannot be empty!")]
        public string UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Invoice Code cannot be empty!")]
        [RegularExpression(@"^[0-9a-zA-Z]{1,12}$", ErrorMessage = "special characters are not allowed.")]
        public string InvoiceCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Company Name cannot be empty!")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,50}$", ErrorMessage = "special characters are not allowed.")]
        public string CompanyName { get; set; }

        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter Captcha Key")]
        //public string CaptchaKey { set; get; }
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter Captcha Value")]
        //public string CaptchaValue { get; set; }

        public bool SendReport { get; set; }

        public bool SoftCopy { get; set; }

        public bool HardCopy { get; set; }
        public string TestPanel { get; set; }

        public string LabLocationId { get; set; }
    }
}
