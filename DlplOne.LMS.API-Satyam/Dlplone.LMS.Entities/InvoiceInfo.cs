namespace Dlplone.LMS.Entities
{
    public class InvoiceInfo
    {
        public int InvId { get; set; }
        public int CId { get; set; }
        public string? InvoiceCode { get; set; }
        public string? TestPanelCode { get; set; }
        public string? OtherInfo { get; set; }
        public string? BannerImage { get; set; }
        public string?   BannerImageLink { get; set; }
        public string? MoU { get; set; }
        public string? AccountType { get; set; }
        public string? IsPrimaryInvCode { get; set; }
        public string? MoUExpiryDate { get; set; }
        public string? Itype { get; set; }
        public string? Pretest { get; set; }
        public string? Pretestother { get; set; }
        public string? Patientemailid { get; set; }
        public string? DoccOnProcess { get; set; }
    }
}

