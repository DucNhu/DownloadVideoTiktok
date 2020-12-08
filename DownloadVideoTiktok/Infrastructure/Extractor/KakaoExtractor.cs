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
    [ExtractorVideo("kakao")]
    public class KakaoExtractor : BaseExtractor
    {
        private readonly ILogger<KakaoExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        public KakaoExtractor(IOptions<WebConfig> _webConfig,
            ILogger<KakaoExtractor> logger, 
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
                player = "monet_html5",
                referer = url,
                uuid = "1d015ed6465831b3c426a9866c3e0efe",
                service = "kakao_tv",
                section = "channel",
                fields = "seekUrl,abrVideoLocationList",
                playerVersion = "3.5.3",
                startPosition = "0",
                tid = "94c32fb1371ea4e98688e7f34522e7dd",
                profile = "HIGH",
                dteType = "PC",
                continuousPlay = "false",
                contentType = ""
            };

            var result = await HttpGet<JObject>(url: $"https://tv.kakao.com/api/v4/ft/cliplinks/{GetIdFromUrl(url, 4)}/raw",
                @params: _params,
                userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36",
                contentJson: true);

            if (result["statusCode"] != null && result["statusCode"].ToString() == "1") return null;

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var metaImageNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']");

            var avatar = metaImageNode.Attributes["content"].Value;
            var vid = result["vid"].ToString();
            var urlVideo = result["videoLocation"]["url"].ToString();

            return new ExtractorItemModel(nameof(FacebookExtractor), avatar, url, vid, urlVideo);
        }
    }
}
