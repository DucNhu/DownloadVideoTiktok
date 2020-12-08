using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure
{
    public class FileUtility
    {
        private readonly ILogger<FileUtility> _logger;
        private readonly IOptions<WebConfig> webConfig;

        public FileUtility(IOptions<WebConfig> _webConfig,
            ILogger<FileUtility> logger)
        {
            webConfig = _webConfig;
            _logger = logger;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var urlFile = string.Empty;

            if (file.Length > 0)
            {
                var dateFolder = $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}";

                var folderSave = $"{webConfig.Value.PathSaveUploadImage}/{dateFolder}";

                if (!Directory.Exists(folderSave)) Directory.CreateDirectory(folderSave);

                urlFile = $"{dateFolder}/{DateTime.Now:yyyyMMddHHmmssfff}-{file.FileName}";

                var filePath = Path.Combine(webConfig.Value.PathSaveUploadImage, urlFile);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return $"/uploads/images/{urlFile}";
        }
    }
}
