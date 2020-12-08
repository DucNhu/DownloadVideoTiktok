using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DownloadVideoTiktok.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace DownloadVideoTiktok.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly ILogger<UploadController> logger;
        private readonly IOptions<WebConfig> webConfig;

        public UploadController(ILogger<UploadController> logger,
            IOptions<WebConfig> webConfig)
        {
            this.logger = logger;
            this.webConfig = webConfig;
        }

        [HttpPost("/upload-editor")]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            var urlFile = string.Empty;
            var fileName = string.Empty;

            foreach (var file in collection.Files)
            {
                if (file.Length > 0)
                {
                    var dateFolder = $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}";

                    var folderSave = $"{webConfig.Value.PathSaveUploadImage}/{dateFolder}";

                    fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}-{file.FileName}";

                    if (!Directory.Exists(folderSave)) Directory.CreateDirectory(folderSave);

                    urlFile = $"{dateFolder}/{fileName}";

                    var filePath = Path.Combine(webConfig.Value.PathSaveUploadImage, urlFile);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            return Content(JsonConvert.SerializeObject(new
            {
                uploaded = 1,
                fileName = fileName,
                url = $"/uploads/images/{urlFile}"
            }), MediaTypeHeaderValue.Parse("application/json"));
        }
    }
}
