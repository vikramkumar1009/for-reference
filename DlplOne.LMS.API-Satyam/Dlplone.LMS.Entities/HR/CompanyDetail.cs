namespace Dlplone.LMS.Entities.HR
{
    public class CompanyDetail
    {
        public string CompanyName { get; set; }
        public string ContactPersonName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string KeyAM_Name { get; set; }
        public string KeyAM_Mobile { get; set; }
        public string KeyAM_Email { get; set; }
        public string CId { get; set; }
        public string CPassword { get; set; }
        public bool isForceRequired { get; set; }
        public string UserName { get; set; }
        public string UPassword { get; set; }
        public string InvoiceCode { get; set; }
        public string IsPrimaryInvCode { get; set; }
        public string MoU { get; set; }
        public string AccountType { get; set; }

        public string BannerImage { get; set; }
        public string BannerImageLink { get; set; }
        public string TestPanelCode { get; set; }
        public string Itype { get; set; }
        public string login_password { get; set; }
        public string salt { get; set; }
        public string is_PasswordExpired { get; set; }
    }
}
