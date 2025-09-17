namespace Dlplone.LMS.Entities.NRLHealth
{
    public class NRLFile
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? AssignedTo { get; set; }
    }
}
