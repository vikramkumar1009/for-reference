using Microsoft.AspNetCore.Http;
namespace Dlplone.LMS.Domain
{
    public interface IFileService
    {
        Task<string> PostFileAsync(IFormFile file);

        Task<List<string>> PostMultiFileAsync(List<IFormFile> files);
        Task<string> PostFileS3Async(IFormFile file);

        Task<byte[]> DownloadFile(string file);
        Task<List<string>> PostMultiFileOnS3Async(List<IFormFile> files);
    }
}
