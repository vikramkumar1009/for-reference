using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dlplone.LMS.Domain;

namespace Dlplone.LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilesController : ControllerBase
    {
        private readonly IFileService fileService;
        private readonly ILogger<FilesController> logger;
        public FilesController(IFileService _fileService, ILogger<FilesController> _logger)
        {
                fileService = _fileService;
                logger = _logger;
        }

        [HttpPost("single")]
        public async Task<string> FileUpload(IFormFile file)
        {

           string fileName = await fileService.PostFileS3Async(file);
           return fileName; 
 
        }
        
        
        [HttpGet("download/single/{file}")]
        public async Task<IActionResult> FileUpload(string file)
        {
           var document = await fileService.DownloadFile(file.Replace("|","/"));

          return File(document, "application/octet-stream", file);
        }
        
        
        
        
        [HttpPost("multi")]
        [DisableRequestSizeLimit]
        public async Task<List<string>> MultiFileUpload(List<IFormFile> files)
        {
            List<string> fileNames = await fileService.PostMultiFileOnS3Async(files);
            return fileNames;
        }
    }
}
