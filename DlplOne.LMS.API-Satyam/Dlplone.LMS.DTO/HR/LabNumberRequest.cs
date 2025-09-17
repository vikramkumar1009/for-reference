using System.ComponentModel.DataAnnotations;

namespace Dlplone.LMS.DTO.HR
{
    public class LabNumberRequest
    {

        [DataType(DataType.Date, ErrorMessage = "Please enter correct Date formate yyyy-MM-dd")]
        public DateTime fromDate { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Please enter correct Date formate yyyy-MM-dd")]
        public DateTime toDate { get; set; }


        [RegularExpression("[0-9]+$", ErrorMessage = "Lab Number Should be Numeric")]
        public string labNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Report Page")]
        [RegularExpression("[0-9]+$", ErrorMessage = "Invalid data formate for Page")]
        [Range(1, 100)]
        public string page { get; set; }

        [Required(ErrorMessage = "Please Enter Report Size")]
        [RegularExpression("[0-9]+$", ErrorMessage = "Invalid data formate for Size")]
        [Range(1, 100)]
        public string size { get; set; }
        public string invoice_code { get; set; }
        public string patientName { get; set; }
    }
}


