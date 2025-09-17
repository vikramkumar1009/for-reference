namespace Dlplone.LMS.Entities.HR
{
    public class EmpDetails
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpId { get; set; }
        public string EmpMobile { get; set; }
        public string EmpComments { get; set; }
        public string Emailstatus { get; set; }
        public bool SendReport { get; set; }

        public bool SoftCopy { get; set; }

        public bool HardCopy { get; set; }
        public List<int> TestPanels { get; set; }
        public int LabLocationId { get; set; }
    }

    public class TestPanelEntity
    {
        public int ApplicantId { get; set; }
        public int TestPanelId { get; set; }
        public string TestPanel { get; set; }
    }

    public class LabEntity
    {
        public int ApplicantId { get; set; }
        public int LabLocationId { get; set; }
    }

}
