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
using System.Text;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure.Extractor
{
    [ExtractorVideo("ixigua")]
    public class IxiguaExtractor : BaseExtractor
    {
        private readonly ILogger<IxiguaExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        //https://i.snssdk.com/video/urls/1/toutiao/mp4/v02004580000bprm5i3pqv6fb375q9a0
        public IxiguaExtractor(IOptions<WebConfig> _webConfig,
            ILogger<IxiguaExtractor> logger, 
            INodeServices nodeServices)
        {
            webConfig = _webConfig;
            _logger = logger;
            this.nodeServices = nodeServices;
        }

        public override async Task<ExtractorItemModel> GetVideo(string url)
        {
            await Task.Delay(0);

            var web = new HtmlWeb();
            var doc = web.Load(url);

            var scriptDataNode = doc.DocumentNode.SelectSingleNode("//script[@id='SSR_HYDRATED_DATA']");
            var metaImageNode = doc.DocumentNode.SelectSingleNode("//meta[@name='og:image']");

            var _jData = JObject.Parse(scriptDataNode.InnerText.Replace("window._SSR_HYDRATED_DATA=", string.Empty));

            var avatar = metaImageNode.Attributes["content"].Value;
            var vid = _jData["anyVideo"]["gidInformation"]["packerData"]["video"]["videoResource"]["vid"].ToString();
            var urlVideo = string.Empty;

            foreach (var item in _jData["anyVideo"]["gidInformation"]["packerData"]["video"]["videoResource"]["dash"]["dynamic_video"]["dynamic_video_list"] as JArray)
            {
                urlVideo = Encoding.UTF8.GetString(Convert.FromBase64String(item["main_url"].ToString()));
            }

            return new ExtractorItemModel(nameof(IxiguaExtractor), avatar, url, vid, urlVideo);
        }
    }
}
