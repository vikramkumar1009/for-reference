namespace Dlplone.LMS.Entities
{
    public class CompanyUpdate
    {
        public int CId { get; set; }
        public string VCompanyName { get; set; }
        public string VUsername { get; set; }
        public string VCPassword { get; set; }  
        public string VContactPersonName { get; set; }
        public string VMobileNumber { get; set; }
        public string VEmail { get; set; }
        public string VKeyAM_Name { get; set; }
        public string VKeyAM_Mobile { get; set; }
        public string VKeyAM_Email { get; set; }
        public string CompanyDomain { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyLogo { get; set; }
        public bool BlockFurtherReports { get; set; }
    }
}


