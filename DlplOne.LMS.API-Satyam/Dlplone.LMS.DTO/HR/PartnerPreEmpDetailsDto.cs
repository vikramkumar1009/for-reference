using System.ComponentModel.DataAnnotations;

namespace Dlplone.LMS.DTO.HR
{
    public class PartnerPreEmpDetailsDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserId cannot be empty!")]
        public string UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "email cannot be empty!")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "name cannot be empty!")]
        public string Name { get; set; }
        public string InvoiceCode { get; set; }
        public string TestPanelCode { get; set; }
        public string Itype { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Employee Id cannot be empty!")]
        public string Eid { get; set; }
        public string ComId { get; set; }
        public string HRComments { get; set; }
        public string Mobile { get; set; }
    }
}
