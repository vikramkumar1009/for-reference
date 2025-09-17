namespace Dlplone.LMS.DTO.HR
{
    public class XCubeLabDto
    {
        public string status { get; set; }
        public string message { get; set; }
        public data data { get; set; }
    }

    public class data
    {
        public string invoice_code { get; set; }
        public string page { get; set; }
        public string size { get; set; }
        public List<result> result { get; set; }
        public int count { get; set; }
    }

    public class result
    {
        public string _id { get; set; }
        public string lab_number { get; set; }
        public string pid { get; set; }
        public string mobile_no { get; set; }
        public string given_name { get; set; }
        public string middle_name { get; set; }
        public string surname { get; set; }
        public string sex { get; set; }
        public string dob { get; set; }
        public string reportdate { get; set; }
        public string invoice_account { get; set; }
        public string registration_lab { get; set; }
        public string report_status { get; set; }
    }
}
