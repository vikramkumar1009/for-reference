namespace Dlplone.LMS.Entities
{
    public class PreEmpReport : Report
    {
        public int ApplicantId { get; set; }
        public int TestPanelId { get; set; }
        public int IsActive { get; set; }
        public string? TestPanel { get; set; }
        public int LabLocation { get; set; }
    }

    public class Report
    {
        public int SendReport { get; set; }
        public int SoftCopy { get; set; }
        public int HardCopy { get; set; }
    }
}
