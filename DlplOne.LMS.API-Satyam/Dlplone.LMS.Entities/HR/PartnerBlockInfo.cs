namespace Dlplone.LMS.Entities.HR
{
    public class PartnerBlockInfo
    {
        public bool BlockFurtherReports { get; set; }
        public int CId { get; set; }
        public DateTime BlockDate { get; set; }
        public DateTime ReportDateFrom { get; set; }
        public DateTime ReportDateTo { get; set; }
    }
}
