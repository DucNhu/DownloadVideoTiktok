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
    [ExtractorVideo("tiktok")]
    public class TiktokExtractor : BaseExtractor
    {
        private readonly ILogger<TiktokExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        public TiktokExtractor(IOptions<WebConfig> _webConfig,
            ILogger<TiktokExtractor> logger,
            INodeServices nodeServices)
        {
            webConfig = _webConfig;
            _logger = logger;
            this.nodeServices = nodeServices;
        }

        public override WebEnums.TypeUrl CheckTypeUrl(string url)
        {
            var _uri = new Uri(url);

            if (_uri.Segments.Length == 2) return WebEnums.TypeUrl.USER;

            if (_uri.Segments.Length == 3 && _uri.Segments[1] == "tag/") return WebEnums.TypeUrl.HASHTAG;

            return WebEnums.TypeUrl.VIDEO;
        }

        public override async Task<ExtractorItemModel> GetVideo(string url)
        {
            var _params = new
            {
                itemId = GetIdFromUrl(url, 3),
                language = "vi"
            };

            var linkApi = BuildLinkApi("https://m.tiktok.com/api/item/detail/", _params);

            (var signature, var verifyFp, var userAgent) = await GetSignatureFromApi(linkApi);

            var result = await HttpGet<JObject>(url: $"{linkApi}&verifyFp={verifyFp}&_signature={signature}",
               userAgent: userAgent,
               contentJson: true,
               referrer: "https://www.tiktok.com/trending?lang=en");

            if (result["statusCode"].ToString() == "1") return null;

            return new ExtractorItemModel(nameof(TiktokExtractor),
                result["itemInfo"]["itemStruct"]["video"]["cover"].ToString(),
                url,
                result["itemInfo"]["itemStruct"]["video"]["id"].ToString(),
                result["itemInfo"]["itemStruct"]["video"]["downloadAddr"].ToString());//$"https://api2.musical.ly/aweme/v1/playwm/?video_id={result["itemInfo"]["itemStruct"]["video"]["id"]}"
        }

        public override async Task<List<ExtractorItemModel>> GetUserPost(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var scriptDataNode = doc.DocumentNode.SelectSingleNode("//script[@id='__NEXT_DATA__']");

            var _jData = JObject.Parse(scriptDataNode.InnerText);

            var _userId = _jData["props"]["pageProps"]["userData"]["userId"].ToString();
            var _secUid = _jData["props"]["pageProps"]["userData"]["secUid"].ToString();

            return await GetUserPost(url, _userId, _secUid, "0");
        }

        public async Task<List<ExtractorItemModel>> GetUserPost(string url, string userID, string secUID, string maxCursor = "0")
        {
            var _params = new
            {
                count = 30,
                id = userID,
                type = 1,
                secUid = secUID,
                maxCursor = maxCursor,
                minCursor = 0,
                sourceType = 8,
                appId = 1180,
                region = "VN",
                language = "vi"
            };

            var linkApi = BuildLinkApi("https://m.tiktok.com/api/item_list/", _params);

            (var signature, var verifyFp, var userAgent) = await GetSignatureFromApi(linkApi);

            var result = await HttpGet<JObject>(url: $"{linkApi}&verifyFp={verifyFp}&_signature={signature}",
               userAgent: userAgent,
               contentJson: true,
               referrer: "https://www.tiktok.com/trending");

            var listResult = new List<ExtractorItemModel>();

            if (result["items"] != null)
            {
                foreach (var item in result["items"] as JArray)
                {
                    if (item["video"] == null) continue;

                    listResult.Add(new ExtractorItemModel(nameof(TiktokExtractor),
                        item["video"]["cover"].ToString(),
                        $"{url}/video/{item["id"]}",
                        item["video"]["id"].ToString(),
                        item["video"]["downloadAddr"].ToString(),//$"https://api2.musical.ly/aweme/v1/playwm/?video_id={item["video"]["id"]}",
                        item["music"] != null ? item["music"]["playUrl"].ToString() : string.Empty));
                }
            }

            if (result["hasMore"] != null && result.Value<bool>("hasMore") && result["items"] != null)
            {
                var listMore = await GetUserPost(url, userID, secUID, result["maxCursor"].ToString());

                listResult.AddRange(listMore);
            }

            return listResult;
        }

        public async Task<List<ExtractorItemModel>> GetHashtagPost(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var scriptDataNode = doc.DocumentNode.SelectSingleNode("//script[@id='__NEXT_DATA__']");

            var _jData = JObject.Parse(scriptDataNode.InnerText);

            var _id = _jData["props"]["pageProps"]["challengeData"]["challengeId"].ToString();

            return await GetHashtagPost(url, _id, 0);

        }

        public async Task<List<ExtractorItemModel>> GetHashtagPost(string url, string id, int maxCursor = 0)
        {
            var _params = new
            {
                secUid = "",
                id = id,
                type = 3,
                count = 30,
                minCursor = 0,
                maxCursor = maxCursor,
                shareUid = "",
                lang = ""
            };

            var listResult = new List<ExtractorItemModel>();

            var linkApi = BuildLinkApi("https://m.tiktok.com/share/item/list", _params);

            (var signature, var verifyFp, var userAgent) = await GetSignatureFromApi(linkApi);

            var result = await HttpGet<JObject>(url: $"{linkApi}&verifyFp={verifyFp}&_signature={signature}",
               userAgent: userAgent,
               contentJson: true,
               referrer: url);

            if (result["body"] != null)
            {
                foreach (var item in result["body"]["itemListData"] as JArray)
                {
                    if (item["itemInfos"] == null) continue;

                    listResult.Add(new ExtractorItemModel(nameof(TiktokExtractor),
                           (item["itemInfos"]["covers"] as JArray)[0].ToString(),
                           $"https://www.tiktok.com/@{item["authorInfos"]["uniqueId"]}/video/{item["itemInfos"]["id"]}",
                           item["itemInfos"]["id"].ToString(),
                           $"https://api2.musical.ly/aweme/v1/playwm/?video_id={item["itemInfos"]["id"]}",
                           item["musicInfos"] != null && (item["musicInfos"]["playUrl"] as JArray).Count > 0 ? (item["musicInfos"]["playUrl"] as JArray)[0].ToString() : string.Empty));
                }
            }

            if (result["body"]["hasMore"] != null && result["body"].Value<bool>("hasMore"))
            {
                var listMore = await GetHashtagPost(url, id, result["body"]["maxCursor"].ToObject<int>());

                listResult.AddRange(listMore);
            }

            return listResult;
        }

        private string GetSignatureFromPython(string url, string str, int @try = 1)
        {
            var result = string.Empty;

            try
            {
                var processStart = new ProcessStartInfo(webConfig.Value.PythonPath);
                processStart.UseShellExecute = false;
                processStart.RedirectStandardOutput = true;
                processStart.CreateNoWindow = true;
                processStart.WindowStyle = ProcessWindowStyle.Minimized;
                processStart.Arguments = $"{webConfig.Value.PythonSignature} TIKTOK {url} {str}";
                var process = new Process();
                process.StartInfo = processStart;
                process.Start();
                result = process.StandardOutput.ReadLine();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetSignature|{ex.Message}|{ex.StackTrace}");
            }

            if (string.IsNullOrEmpty(result) && @try < 3) return GetSignatureFromPython(url, str, @try + 1);

            return result;
        }

        protected async Task<(string, string, string)> GetSignatureFromApi(string url, int @try = 1)
        {
            var signature = string.Empty;
            var verifyFp = string.Empty;
            var userAgent = string.Empty;

            try
            {
                var jData = await HttpPost<JObject>(webConfig.Value.TiktokSignatureApi, new { url }, contentJson: true);

                signature = jData["signature"].ToString();
                verifyFp = jData["verifyFp"].ToString();
                userAgent = jData["userAgent"].ToString();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetSignatureFromCefApi|{ex.Message}|{ex.StackTrace}");
            }

            if (string.IsNullOrEmpty(signature) && @try <= 5)
            {
                await Task.Delay(1000);

                return await GetSignatureFromApi(url, @try + 1);
            }

            return (signature, verifyFp, userAgent);
        }

        protected async Task<(string, string, string)> GetSignatureFromNodeApi(string url)
        {
            var jData = await HttpPost<JObject>(webConfig.Value.TiktokSignatureNodeApi, url, contentJson: true);

            return (jData["signature"].ToString(), jData["verifyFp"].ToString(), jData["userAgent"].ToString());
        }

        protected async Task<(string, string)> GetSignatureFromNode(string url)
        {
            var jData = JObject.Parse(await nodeServices.InvokeAsync<string>("./scripts/js/tiktok-get-signature", url));

            return (jData["signature"].ToString(), jData["verifyFp"].ToString());
        }
    }
}
