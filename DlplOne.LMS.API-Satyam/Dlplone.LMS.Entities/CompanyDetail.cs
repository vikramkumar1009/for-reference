namespace Dlplone.LMS.Entities
{
    public class CompanyDetail : Company
    {
        public string CPassword { get; set; }
        public string MobileNumber { get; set; }
        public string KeyAM_Name { get; set; }
        public string KeyAM_Mobile { get; set; }
        public string KeyAM_Email { get; set; }
        public string CompanyDomain { get; set; }
        public string CompanyShortName { get; set; }
        public string CompanyLogo { get; set; }
        public bool BlockFurtherReports { get; set; }
    }
}
