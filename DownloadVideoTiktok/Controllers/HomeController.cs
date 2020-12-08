using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DownloadVideoTiktok.Models;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using DownloadVideoTiktok.Services;
using DownloadVideoTiktok.Infrastructure;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using DownloadVideoTiktok.Infrastructure.Extractor;

namespace DownloadVideoTiktok.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private static HttpClient Client { get; } = new HttpClient();
        private readonly HistoryDownloadService historyDownloadService;
        private readonly UserPackageService userPackageService;
        private readonly ArticleService articleService;
        private readonly IServiceProvider serviceProvider;

        public HomeController(ILogger<HomeController> logger,
            HistoryDownloadService historyDownloadService,
            UserPackageService userPackageService,
            IServiceProvider serviceProvider,
            ArticleService articleService)
        {
            _logger = logger;
            this.historyDownloadService = historyDownloadService;
            this.userPackageService = userPackageService;
            this.serviceProvider = serviceProvider;
            this.articleService = articleService;
        }

        public IActionResult Index()
        {
            var model = articleService.GetByCode("CONTENT_HOME");
            ViewBag.FooterContent = articleService.GetByCode("CONTENT_HOME_FOOTER");
            ViewBag.GuideContent = articleService.GetByCode("CONTENT_HOME_GUIDE");
            ViewBag.HighLightContent = articleService.GetByCode("CONTENT_HOME_HIGHLIGHT");
            ViewBag.SourceContent = articleService.GetByCode("CONTENT_HOME_SOURCE");

            //var arr = new string[] { "Youtube", "Douyin", "Youku", "Facebook", "Bilibili", "Dailymotion", "Ixigua", "Kakao" };

            //foreach (var item in arr)
            //{
            //    var article = new Article()
            //    {
            //        Name = $"Nội dung trang {item.ToLower()}",
            //        Code = $"CONTENT_{item.ToUpper()}",
            //        TypeCode = $"CONTENT",
            //        Language = $"en",
            //        IsActive = true,
            //        DisplayOrder = 1,
            //        Detail = $"<h2>{item} video downloader online free.</h2>",
            //        SEOTitle = $"Download video {item} without watermark/ logo. {item} video downloader",
            //        SEODescrition = $"videodownhd is the best way to save your favorite {item} videos. That provides online {item} videos download, copy and paste video url input box above and download.",
            //        SEOKeywords = $"download, video, audio, mp4, mp3, youtube, tiktok, douyin, no watermark, watermark, hd, 4k..."
            //    };

            //    article.Ascii = $"noi-dung-trang-{item.ToLower()}";
            //    article.DateCreated = DateTime.Now;
            //    article.IsDeleted = false;

            //    articleService.Create(article);
            //}

            return View(model);
        }

        [HttpGet("/robots.txt")]
        public IActionResult Robots()
        {
            return Content(System.IO.File.ReadAllText("robots.txt"), "text/plain", System.Text.Encoding.UTF8);
        }

        [HttpGet("/sitemap.xml")]
        public IActionResult Sitemap()
        {
            return Content(System.IO.File.ReadAllText("sitemap.xml"), "application/xml");
        }

        [HttpGet("/free-vip")]
        public IActionResult FreeVip()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet("/get-info-video")]
        public async Task<IActionResult> GetInfoVideo(string url)
        {
            try
            {
                var results = await ProcessLink(url);

                if (results == null || !results.Any())
                {
                    return new JsonResult(new
                    {
                        statusCode = 1,
                        message = "No videos",
                        data = results
                    });
                }

                results.ForEach(item =>
                {
                    var _history = new HistoryDownload()
                    {
                        UserId = "FROM_TOOL",
                        Name = item.Name,
                        Avatar = item.Avatar,
                        Link = item.VideoUrl,
                        Source = item.Source,
                        DateCreated = DateTime.Now,
                        IsActive = true,
                        IsDeleted = false
                    };

                    historyDownloadService.Create(_history);

                    item.Id = _history.Id;

                    if (item.Name.Contains("Tiktok") || item.Name.Contains("Douyin")) item.VideoUrl = GetLinkDownloadTiktok(item.VideoUrl);
                });

                return new JsonResult(new
                {
                    statusCode = 0,
                    message = "Get info success",
                    data = results.Select(c => new
                    {
                        picture = c.Avatar,
                        urlVideo = c.VideoUrl
                    }).ToList()
                });
            }
            catch (Exception)
            {
                return new JsonResult(new
                {
                    statusCode = 2,
                    message = "Get info failed",
                    data = new List<object>()
                });
            }
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetLink(string type)
        {
            if (string.IsNullOrEmpty(Request.Query["url"]))
            {
                var model = articleService.GetByCode($"CONTENT_{type.ToUpper()}");

                ViewBag.GuideContent = articleService.GetByCode("CONTENT_HOME_GUIDE");

                return View(model);
            };

            var _url = Request.Query["url"].ToString().Trim();

            var checkVideoType = CheckTypeUrl(_url);

            if (checkVideoType != WebEnums.TypeUrl.VIDEO) return View(null);

            var results = await ProcessLink(_url);

            var item = results.Count > 0 ? results[0] : null;

            if (item != null)
            {
                var _history = new HistoryDownload()
                {
                    UserId = User.Identity.IsAuthenticated ? UserId : null,
                    Name = item.Name,
                    Avatar = item.Avatar,
                    Link = item.VideoUrl,
                    Source = item.Source,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };

                historyDownloadService.Create(_history);

                item.Id = _history.Id;
            }

            return View("~/Views/Home/GetLinkResult.cshtml", item);
        }

        [HttpGet("/features")]
        public IActionResult Feature()
        {
            var model = articleService.GetByCode("CONTENT_FEATURES");

            return View(model);
        }

        [HttpGet("/faq")]
        public IActionResult Faq()
        {
            (var list, var total) = articleService.GetByType("FAQ", 0, 100);

            var model = new PageListModel<Article>
            {
                List = list,
                Total = total
            };

            return View(model);
        }

        [HttpGet("/guide")]
        public IActionResult Guide()
        {
            (var list, var total) = articleService.GetByType("GUIDE", 0, 100);

            var model = new PageListModel<Article>
            {
                List = list,
                Total = total
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("/get-video")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetVideo(string url)
        {
            try
            {
                //if (!IsCheckReCaptcha) return PartialView("~/Views/Home/_AlertError.cshtml", "Please verify captcha");

                var isFreeVip = !string.IsNullOrEmpty(Request.Headers["Referer"]) && Request.Headers["Referer"].ToString().Contains("/free-vip");

                var arrLink = url.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Where(c => !string.IsNullOrEmpty(c)).ToList();

                var isMultipleOrChanel = arrLink.Count(c => !string.IsNullOrEmpty(c)) > 1;

                var isOnlyVideoUrl = true;

                var requestId = Guid.NewGuid().ToString();

                var numberRequestVip = historyDownloadService.CountVip(UserId, DateTime.Now.Date, DateTime.Now.Date.AddDays(1).AddSeconds(-1), true);

                foreach (var item in arrLink) isOnlyVideoUrl = isOnlyVideoUrl && CheckTypeUrl(item) == WebEnums.TypeUrl.VIDEO;

                var isVipRequest = isMultipleOrChanel || !isOnlyVideoUrl;

                if (isVipRequest && !User.Identity.IsAuthenticated && !isFreeVip) return PartialView("~/Views/Home/_AlertLoginPartial.cshtml");

                var isHasVip = isFreeVip || userPackageService.GetDateExpiredUser(UserId) >= DateTime.Now;

                if (isVipRequest && !isHasVip && numberRequestVip >= 5) return PartialView("~/Views/Home/_AlertUpgradePartial.cshtml");

                var listResults = new List<ExtractorItemModel>();

                foreach (var item in arrLink)
                {
                    var _list = await ProcessLink(item);

                    if (_list != null)
                    {
                        _list.ForEach(c => c.RequestSource = item);

                        listResults.AddRange(_list);
                    }
                }

                foreach (var item in listResults)
                {
                    var linkDownload = string.Empty;

                    if (!string.IsNullOrEmpty(item.Source))
                    {
                        var _history = new HistoryDownload()
                        {
                            UserId = User.Identity.IsAuthenticated ? UserId : null,
                            RequestId = requestId,
                            Name = item.Name,
                            Avatar = item.Avatar,
                            Link = item.VideoUrl,
                            Source = item.Source,
                            RequestLink = item.RequestSource,
                            DateCreated = DateTime.Now,
                            IsVipRequset = isVipRequest,
                            IsActive = true,
                            IsDeleted = false
                        };

                        historyDownloadService.Create(_history);

                        item.Id = _history.Id;

                        linkDownload = $"/download-video?id={_history.Id}";
                    }

                    item.LinkDownloadVideo = linkDownload;
                }

                ViewBag.IsVip = isHasVip;

                return PartialView("~/Views/Home/_ListVideoPartial.cshtml", listResults);
            }
            catch (Exception)
            {
                return PartialView("~/Views/Home/_AlertError.cshtml", "Something wrong.");
            }
        }

        [HttpPost("/download-zip")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DownloadZip(string[] ids)
        {
            byte[] zipBytes = null;

            using (var compressedFileStream = new MemoryStream())
            {
                using (ZipArchive zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, leaveOpen: true))
                {
                    foreach (var id in ids)
                    {
                        var history = historyDownloadService.Get(id);

                        var fileBytes = await Client.GetByteArrayAsync(GetLinkDownloadTiktok(history.Link));

                        var zipEntry = zipArchive.CreateEntry($"{id}.mp4");

                        using (var entryStream = new MemoryStream(fileBytes))
                        using (var zipEntryStream = zipEntry.Open())
                        {
                            entryStream.CopyTo(zipEntryStream);
                        }

                        history.IsDownload = true;

                        historyDownloadService.Update(id, history);
                    }
                }

                zipBytes = compressedFileStream.ToArray();
            }

            Response.Headers.Add("fileName", $"{DateTime.Now:yyyyMMddHHmmssfff}.zip");

            return new FileContentResult(zipBytes, new MediaTypeHeaderValue("application/octet-stream"))
            {
                FileDownloadName = $"{DateTime.Now:yyyyMMddHHmmssfff}.zip"
            };
        }

        [HttpPost("/get-url-video")]
        public IActionResult GetUrlVideo(string id)
        {
            var history = historyDownloadService.Get(id);

            var url = $"/download-video?id={id}";

            if (history.Name.ToLower().Contains("tiktok") || history.Name.ToLower().Contains("douyin")) url = GetLinkDownloadTiktok(history.Link);

            return new JsonResult(new
            {
                error = false,
                message = "Get video success",
                data = new
                {
                    url = url,
                    fileName = $"{DateTime.Now:yyyyMMddHHmmssfff}.mp4"
                }
            });
        }

        [HttpGet("/download-video")]
        public async Task<IActionResult> DownloadVideo(string id)
        {
            var history = historyDownloadService.Get(id);

            if (history.Name.Contains("Tiktok") || history.Name.Contains("Douyin")) history.Link = GetLinkDownloadTiktok(history.Link);

            var resHead = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Head, history.Link));

            var stream = await Client.GetStreamAsync(history.Link);

            history.IsDownload = true;

            historyDownloadService.Update(id, history);

            Response.ContentLength = resHead.Content.Headers.ContentLength;

            return new FileStreamResult(stream, new MediaTypeHeaderValue("application/octet-stream"))
            {
                FileDownloadName = $"{DateTime.Now:yyyyMMddHHmmssfff}.mp4"
            };
        }

        public WebEnums.TypeUrl CheckTypeUrl(string url)
        {
            try
            {
                var _uri = new Uri(url);

                var _typeService = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => typeof(BaseExtractor).IsAssignableFrom(p)
                    && p.GetCustomAttribute<ExtractorVideoAttribute>() != null
                    && _uri.Host.ToLower().Contains(p.GetCustomAttribute<ExtractorVideoAttribute>()?.Host))
                    .FirstOrDefault();

                if (_typeService != null)
                {
                    var service = (BaseExtractor)serviceProvider.GetService(_typeService);
                    return service.CheckTypeUrl(url);
                };
            }
            catch (Exception)
            {

            }

            return WebEnums.TypeUrl.VIDEO;
        }

        public async Task<List<ExtractorItemModel>> ProcessLink(string url, int @try = 1)
        {
            var listResult = new List<ExtractorItemModel>();

            try
            {
                var _uri = new Uri(url);

                var _typeService = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => typeof(BaseExtractor).IsAssignableFrom(p)
                    && p.GetCustomAttribute<ExtractorVideoAttribute>() != null
                    && _uri.Host.ToLower().Contains(p.GetCustomAttribute<ExtractorVideoAttribute>()?.Host))
                    .FirstOrDefault();

                if (_typeService != null)
                {
                    var service = (BaseExtractor)serviceProvider.GetService(_typeService);
                    listResult = await service.ExtractorVideos(url);
                };
            }
            catch (Exception)
            {

            }

            if (listResult.Count() == 0 && @try <= 3)
            {
                await Task.Delay(2000);

                return await ProcessLink(url, @try + 1);
            }

            return listResult;
        }

        private string GetLinkDownloadTiktok(string urlVideo, int _try = 1)
        {
            var link = string.Empty;

            try
            {
                var shortUrlVideo = urlVideo.Contains("aweme/v1/playwm/?video_id") || urlVideo.Contains("aweme/v1/play/?video_id")
                    ? urlVideo
                    : $"https://api2-16-h2.musical.ly/aweme/v1/play/?video_id={GetVidTiktok(urlVideo)}&line=0&ratio=default&media_type=4&vr_type=0";

                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(shortUrlVideo);
                    request.UserAgent = urlVideo.ToLower().Contains("aweme.snssdk.com")
                        ? "Mozilla/5.0 (iPad; CPU OS 7_0_4 like Mac OS X) AppleWebKit/537.51.1 (KHTML, like Gecko) Mercury/8.7 Mobile/11B554a Safari/9537.53"
                        : string.Empty;//"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36 Edg/81.0.416.72";
                    request.AllowAutoRedirect = false;
                    var response = (HttpWebResponse)request.GetResponse();
                    link = response.Headers["Location"];
                    response.Close();
                }
                catch (WebException ex)
                {
                    link = ((HttpWebResponse)ex.Response).Headers["Location"].Replace("http://", "https://");
                }
            }
            catch (Exception)
            {
                if (_try < 3) return GetLinkDownloadTiktok(urlVideo, _try + 1);
            }

            return string.IsNullOrEmpty(link) ? urlVideo : link;
        }

        private string GetVidTiktok(string urlVideo, int _try = 1)
        {
            var vid = string.Empty;

            try
            {
                using var webClient = new WebClient();

                webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.125 Safari/537.36";

                webClient.Headers["Range"] = $"bytes=1000-{_try * 10000}";

                webClient.Headers["accept-encoding"] = $"gzip, deflate, br";

                webClient.Headers["accept-Language"] = $"en-US,en;q=0.9";

                webClient.Headers["Accept"] = $"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";

                var result = webClient.DownloadString(urlVideo);

                var positionVid = result.IndexOf("vid:");

                if (positionVid > -1) vid = result.Substring(positionVid + 4, 32);
            }
            catch (Exception ex)
            {

            }

            if (string.IsNullOrEmpty(vid) && _try < 10) return GetVidTiktok(urlVideo, _try + 1);

            return vid;
        }
    }
}
