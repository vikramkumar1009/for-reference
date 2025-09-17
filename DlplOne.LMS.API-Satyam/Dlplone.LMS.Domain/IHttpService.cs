namespace Dlplone.LMS.Domain
{
    public interface IHttpService
    {
        Task<T> Get<T>(string url, Dictionary<string, string> headers = null);
        Task<TO> PostRequest<TI,TO>(string apiUrl, TI postObject, Dictionary<string, string> headers = null);
        Task PutRequest<T>(string apiUrl, T putObject, Dictionary<string, string> headers = null);
    }
}
