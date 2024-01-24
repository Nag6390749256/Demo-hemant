using DAPPER_CURD.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace DAPPER_CURD.AppCode.Hellper
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IRequestInfo _rinfo;
        public FileUploadService(IRequestInfo requestInfo)
        {
            _rinfo = requestInfo;
        }
        public AppResponse Upload(FileUploadModel request)
        {
            var response = new AppResponse
            {
                StatusCode = -1,
                ResponseText = "Failed to upload."
            };
            try
            {
                StringBuilder sb = new StringBuilder();
                if (!request.FilePath.Contains("wwwroot"))
                {
                    request.FilePath = $"wwwroot/{request.FilePath}";
                }
                sb.Append(request.FilePath);
                if (!Directory.Exists(sb.ToString()))
                {
                    Directory.CreateDirectory(sb.ToString());
                }
                var filename = ContentDispositionHeaderValue.Parse(request.file.ContentDisposition).FileName.Trim('"');
                string originalExt = Path.GetExtension(filename).ToLower();
                string[] Extensions = { ".png", ".jpeg", ".jpg", ".webp", ".pdf" };
                if (!Extensions.Contains(originalExt))
                {
                    response.StatusCode = -1;
                    response.ResponseText = "You can only upload JPEG, JPG, and PNG files.";
                }
                if (string.IsNullOrEmpty(request.FileName))
                {
                    request.FileName = filename;
                }
                sb.Append($"{request.FileName}{originalExt}");
                using (FileStream fs = File.Create(sb.ToString()))
                {
                    request.file.CopyTo(fs);
                    fs.Flush();
                }
                response.StatusCode = 1;
                response.ResponseText = $"{_rinfo.GetDomain()}/{request.FilePath.Replace("wwwroot/", "")}{request.FileName}{originalExt}";
            }
            catch (Exception ex)
            {
                response.StatusCode = -1;
                response.ResponseText = "Error in file uploading. Try after sometime...";
            }
            return response;
        }
    }
    public class FileUploadModel
    {
        public IFormFile file { get; set; }
        public string? base64 { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}

