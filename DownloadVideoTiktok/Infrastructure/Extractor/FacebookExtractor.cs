using DownloadVideoTiktok.Infrastructure.Extensions;
using DownloadVideoTiktok.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DownloadVideoTiktok.Infrastructure.Extractor
{
    [ExtractorVideo("facebook")]
    public class FacebookExtractor : BaseExtractor
    {
        private readonly ILogger<FacebookExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        public FacebookExtractor(IOptions<WebConfig> _webConfig,
            ILogger<FacebookExtractor> logger, 
            INodeServices nodeServices)
        {
            webConfig = _webConfig;
            _logger = logger;
            this.nodeServices = nodeServices;
        }

        public override async Task<ExtractorItemModel> GetVideo(string url)
        {
            var avatar = string.Empty;
            var urlVideo = string.Empty;
            var vid = string.Empty;

            var contentPage = await HttpGet(url,
                userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36");

            foreach (var line in contentPage.ToLines())
            {
                if (line.Contains("meta") && line.Contains("og:image"))
                {
                    var match = Regex.Match(line, "<meta property=\"og:image\" content=\"(.*?)\" />");

                    avatar = HttpUtility.HtmlDecode(match.Groups[1].Value);
                }

                if (line.Contains("videoData") && line.Contains("hd_src"))
                {
                    var match = Regex.Match(line, "hd_src:\"(.*?)\"");

                    urlVideo = HttpUtility.HtmlDecode(match.Groups[1].Value);
                }

                if (line.Contains("videoData") && line.Contains("video_id"))
                {
                    var match = Regex.Match(line, "video_id:\"(.*?)\"");

                    vid = HttpUtility.HtmlDecode(match.Groups[1].Value);
                }
            }

            return new ExtractorItemModel(nameof(FacebookExtractor), avatar, url, vid, urlVideo);
        }
    }
}
