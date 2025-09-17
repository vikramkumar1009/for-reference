using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Dlplone.LMS.Domain.Infrastructure
{
    public class FileService : IFileService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<FileService> logger;
        public FileService(IConfiguration _configuration, ILogger<FileService> _logger)
        {
            configuration = _configuration;  
            logger = _logger;
        }
        public async Task<string> PostFileAsync(IFormFile file)
        {
            try
            {
                var fileName = uniqueNumber() + file.FileName;
                using (var stream = new FileStream("D:\\files\\" + fileName, FileMode.CreateNew))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName; 
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task<string> PostFileS3Async(IFormFile file)
        {
            try
            {
                var fileName = file.FileName + "_" + uniqueNumber();
                var bucketName = configuration["AWSSettings:BucketName"];
                var utility = GetTransferUtility();
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);
                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = fileName,
                        BucketName = bucketName,
                        CannedACL = S3CannedACL.Private,
                        ContentType = file.ContentType
                    };
                    await utility.UploadAsync(uploadRequest);
                }
                return fileName;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       public async Task<List<string>> PostMultiFileAsync(List<IFormFile> files)
        {
            try
            {
                List<string> list = new List<string>();
                string fileName = string.Empty;
                foreach (var item in files)
                {
                    fileName = uniqueNumber() + item.FileName;
                    using (var stream = new FileStream("D:\\files\\" + fileName , FileMode.CreateNew))
                    {
                        await item.CopyToAsync(stream);
                    }
                    list.Add(fileName);
                }
                return list; 
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task<List<string>> PostMultiFileOnS3Async(List<IFormFile> files)
        {
            try
            {
                List<string> list = new List<string>();
                string fileName = string.Empty;
                var bucketName = configuration["AWSSettings:BucketName"];
                var utility = GetTransferUtility();
                foreach (var file in files)
                {
                    fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + uniqueNumber() + Path.GetExtension(file.FileName);
                    using (var newMemoryStream = new MemoryStream())
                    {
                        file.CopyTo(newMemoryStream);
                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = newMemoryStream,
                            Key = fileName,
                            BucketName = bucketName,
                            CannedACL = S3CannedACL.Private,
                            ContentType = file.ContentType
                        };
                        await utility.UploadAsync(uploadRequest);
                    }
                    list.Add(fileName);
                }
                return list; 
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<byte[]> DownloadFile(string file)
        {
            MemoryStream ms = null;
            var bucketName = configuration["AWSSettings:BucketName"];
            try
            {
                GetObjectRequest getObjectRequest = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = file
                };
                var client = GetClient();
                using (var response = await client.GetObjectAsync(getObjectRequest))
                {
                    if (response.HttpStatusCode == HttpStatusCode.OK)
                    {
                        using (ms = new MemoryStream())
                        {
                            await response.ResponseStream.CopyToAsync(ms);
                        }
                    }
                }

                if (ms is null || ms.ToArray().Length < 1)
                    throw new FileNotFoundException(string.Format("The document '{0}' is not found", file));

                return ms.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected string uniqueNumber()
        {
            Random r = new Random();
            string hidCID = DateTime.Now.ToString("dd MM yyyy hh:mm:ss.fff").Replace(":", "").Replace(" ", "").Replace(".", "") + "" + r.Next(100, 999);
            return hidCID;
        }
        private TransferUtility GetTransferUtility()
        {
            string accessKey = configuration["AWSSettings:AccessKey"];
            string secretKey = configuration["AWSSettings:SecretKey"];
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var config = new AmazonS3Config()
            {
                RegionEndpoint = RegionEndpoint.APSouth1
            };
            var client = new AmazonS3Client(credentials, config);
            var transferUtility = new TransferUtility(client);
            return transferUtility; 
        }
        
        private AmazonS3Client GetClient()
        {
            string accessKey = configuration["AWSSettings:AccessKey"];
            string secretKey = configuration["AWSSettings:SecretKey"];
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var config = new AmazonS3Config()
            {
                RegionEndpoint = RegionEndpoint.APSouth1
            };
            var client = new AmazonS3Client(credentials, config);
            return client;
        }
    }
}
