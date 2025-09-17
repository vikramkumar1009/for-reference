namespace Dlplone.LMS.Entities
{
    public class PreEmpInfo : ExpiryDetails
    {
        public int InvId { get; set; }
        public int CId { get; set; }
        public string? InvoiceCode { get; set; }
        public string? AccountType { get; set; }
        public string? TestPanelCode { get; set; }
        public string? OtherInfo { get; set; }
        public string? Itype { get; set; }
        public string? Pretest { get; set; }
        public string? PretestOther { get; set; }
        public string? PatientEmailId { get; set; }
        public string? DoccOnProcess { get; set; }
        public string? CompanyName { get; set; }
    }
    public class ExpiryDetails
    {
        public string? Guid { get; set; }
        public DateTime? Dt { get; set; }
    }
}
