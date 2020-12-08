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
    [ExtractorVideo("dailymotion")]
    public class DailymotionExtractor : BaseExtractor
    {
        private readonly ILogger<DailymotionExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        public DailymotionExtractor(IOptions<WebConfig> _webConfig,
            ILogger<DailymotionExtractor> logger, 
            INodeServices nodeServices)
        {
            webConfig = _webConfig;
            _logger = logger;
            this.nodeServices = nodeServices;
        }

        public override async Task<ExtractorItemModel> GetVideo(string url)
        {
            var _params = new
            {
                app = "com.dailymotion.neon",
                locale = "en",
                client_type = "website"
            };

            var result = await HttpGet<JObject>(url: $"https://www.dailymotion.com/player/metadata/video/{GetIdFromUrl(url, 2)}",
                @params: _params,
                userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36", 
                contentJson: true);

            if (result["statusCode"] != null && result["statusCode"].ToString() == "1") return null;

            var avatar = result["posters"]["360"].ToString();
            var vid = result["id"].ToString();
            var urlVideo = string.Empty;

            var contentPage = await HttpGet((result["qualities"]["auto"] as JArray)[0]["url"].ToString(), 
                userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36 Edg/81.0.416.72");

            foreach (var item in contentPage.ToLines())
            {
                if (item.Contains("#EXT-X-STREAM-INF:BANDWIDTH"))
                {
                    var match = Regex.Match(item, "PROGRESSIVE-URI=\"(.*?)#");

                    urlVideo = HttpUtility.HtmlDecode(match.Groups[1].Value);
                }
            }

            return new ExtractorItemModel(nameof(DailymotionExtractor), avatar, url, vid, urlVideo);
        }
    }
}
