using System;

namespace Dlplone.LMS.Entities
{
    public class InvoiceInsert
    {
        public int VCId { get; set; }
        public string? VInvoiceCode { get; set; }
        public string? VMoU { get; set; }
        public string? VAccountType { get; set; }
        public string? VIsPrimaryInvcode { get; set; }
        public DateTime? MoUExpiryDate { get; set; }
        public string? VTestPanelCode { get; set; }
        public string? VOtherInfo { get; set; }
        public string? VBannerImage { get; set; }
        public string? VBannerImageLink { get; set; }
        public string? VItype { get; set; }
        public string? VPretest { get; set; }
        public string? VPretestOther { get; set; }
        public string? VPatientEmailId { get; set; }
        public string? VDoccOnProcess { get; set; }
        public string? PanelCode { get; set; }
        public string? CustomerType { get; set; }
        public string? LabLocation { get; set; }
    }
}

