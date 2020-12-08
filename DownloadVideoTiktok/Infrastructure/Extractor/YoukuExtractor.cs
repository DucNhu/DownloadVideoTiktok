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
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure.Extractor
{
    [ExtractorVideo("youku")]
    public class YoukuExtractor : BaseExtractor
    {
        private readonly ILogger<YoukuExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        public YoukuExtractor(IOptions<WebConfig> _webConfig,
            ILogger<YoukuExtractor> logger, 
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
                vid = GetIdFromUrl(url, 2).Replace("id_", string.Empty).Replace(".html", string.Empty),
                ccode = "0501",
                client_ip = "0.0.0.0",
                app_ver = "1.0.0",
                client_ts = "1591440481",
                fu = "0",
                vr = "0",
                rst = "mp4",
                dq = "mp4",
                os = "ios",
                bt = "phone",
                bd = "",
                tict = "0",
                d = "0",
                needbf = "1",
                site = "1",
                aw = "w",
                vs = "1.0",
                pver = "1",
                wintype = "xplayer_m3u8",
                play_ability = "1024",
                utid = "h2FiF/MPKFkCASpwXfNrGVeY",
                ckey = "124#BgTL8k5qxG0xA5bqjJcnHeKVVpRFx4SskGO1Me+5ZXguXA0v3UtKPvNm1k5MX57ffuKbw4VoRitwwtoeVZwhgH4j70WsI0AK5r7arrqHiKQ6o5mOeee8oBhBWERXgoNOG72cEXVkxvz7v" +
                "EQc5IPz7cLwAJTkOATOKVoQZ0XeD0H8InYLlTYIm4WZIqXLgTzd1Z2ebUL2gKvm/UwT5wiJm4afI8LpgTG41nIelUX2g7vtIZ/plw/Jm4WZIqXLg5Sd1Z2ZlMLng7OBInYLlwYZmfWxJMbBgmVd1qyel" +
                "ULnmoBiVraLUT/nm4+eX0PXxZfnvwi5uEqGIPHzj+xK2wda3v4WFJK7GnfJIl7R+UEc/Ky1YtGiqlZLbTmvOY4XddhQ4k6BnmXdhNcpbpiWm1sXvUH2BQLqvvbQ4NXCuC8S5Luonbywm4US5A6Z7/R/h" +
                "0141FPyedCww6Eigvm+svCe2U2A3x9xPPVZq3BsIubD7+XA4ccgLBAJ9RHZ7K71uvDd5fAP8xQQxGqLP9V4kZoO8cg0Rx0pgYRlT03fwe5XFuMAQMh2mGtxn8U4zDk/1BRegdijdoM54WYN8UA1LqszV" +
                "eGFSeeE1S+9RFDnPyS3RMctL5a+08lcctaLm792NU3xZZh26wr9zruqrM+8o3vcRqZFqNiAtO+0GpSwohOaGiVtDzs7CxggjfqjAYf7+RY2nDtL83QF8PNHPG4D9JlwCmrZ5I4SAjIiYlb00Os0TgwhV" +
                "s4A/VQvsTeDBjqgFzY058L2Kh7u8bLc1sxF6TUcO3we3WGZsVP="
            };

            var result = await HttpGet<JObject>(url: "https://ups.youku.com/ups/get.json",
                @params: _params,
                userAgent: "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1",
                contentJson: true);

            if (result["statusCode"] != null && result["statusCode"].ToString() == "1") return null;

            var urlVideo = string.Empty;

            var width = 0;

            foreach (var item in result["data"]["stream"] as JArray)
            {
                if (item.Value<int>("width") > width)
                {
                    width = item.Value<int>("width");
                    urlVideo = (item["segs"] as JArray)[0]["cdn_url"].ToString();
                }
            }

            return new ExtractorItemModel(nameof(YoukuExtractor), result["data"]["video"]["logo"].ToString(), url, result["data"]["video"]["encodeid"].ToString(), urlVideo);
        }
    }
}
