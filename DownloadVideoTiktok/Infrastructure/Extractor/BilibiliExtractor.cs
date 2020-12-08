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
    [ExtractorVideo("bilibili")]
    public class BilibiliExtractor : BaseExtractor
    {
        private readonly ILogger<BilibiliExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        //https://api.bilibili.com/x/player/playurl?avid=498306329&cid=197725236
        public BilibiliExtractor(IOptions<WebConfig> _webConfig,
            ILogger<BilibiliExtractor> logger, 
            INodeServices nodeServices)
        {
            webConfig = _webConfig;
            _logger = logger;
            this.nodeServices = nodeServices;
        }

        public override async Task<ExtractorItemModel> GetVideo(string url)
        {
            if(!url.Contains("m.bilibili.com")) url = url.Replace("bilibili.com", "m.bilibili.com").Replace("www.", string.Empty);

            var avatar = string.Empty;
            var urlVideo = string.Empty;
            var vid = string.Empty;

            var contentPage = await HttpGet(url, 
                userAgent: "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1");

            foreach (var line in contentPage.ToLines())
            {
                if (line.Contains("image:"))
                {
                    var match = Regex.Match(line, "image: '(.*?)',");

                    avatar = $"http:{HttpUtility.HtmlDecode(match.Groups[1].Value)}";
                }

                if (line.Contains("video_url:"))
                {
                    var match = Regex.Match(line, "video_url: '(.*?)',");

                    urlVideo = $"https:{HttpUtility.HtmlDecode(match.Groups[1].Value)}";
                }

                if (line.Contains("bvid:"))
                {
                    var match = Regex.Match(line, "bvid: '(.*?)',");

                    vid = HttpUtility.HtmlDecode(match.Groups[1].Value);
                }
            }

            return new ExtractorItemModel(nameof(BilibiliExtractor), avatar, url, vid, urlVideo);
        }
    }
}
