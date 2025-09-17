namespace Dlplone.LMS.Entities.Infrastructure
{
    public class Filter
    {
        public int PageNo { get; set; }
        public int PageLength { get; set; }
        public string SortType { get; set; } = string.Empty;
        public string? SearchTerm { get; set; }
    }
}
