namespace Dlplone.LMS.DTO.HR
{
    public class XCubeResponse<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
