using DownloadVideoTiktok.Models;
using Microsoft.AspNetCore.WebUtilities;
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
    [ExtractorVideo("douyin")]
    public class DouyinExtractor : BaseExtractor
    {
        private readonly ILogger<DouyinExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;

        public DouyinExtractor(IOptions<WebConfig> _webConfig,
            ILogger<DouyinExtractor> logger)
        {
            webConfig = _webConfig;
            _logger = logger;
        }

        public override WebEnums.TypeUrl CheckTypeUrl(string url)
        {
            var _uri = new Uri(url);

            if (_uri.Segments[2] == "user/" && _uri.Segments.Length == 4) return WebEnums.TypeUrl.USER;

            if (_uri.Segments[2] == "challenge/" && _uri.Segments.Length == 4) return WebEnums.TypeUrl.CHANEL;

            return WebEnums.TypeUrl.VIDEO;
        }

        public override async Task<ExtractorItemModel> GetVideo(string url)
        {
            var _params = new
            {
                item_ids = GetIdFromUrl(url, 3)
            };

            var result = await HttpGet<JObject>("https://www.iesdouyin.com/web/api/v2/aweme/iteminfo/",
                _params,
                userAgent: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36", 
                contentJson: true);

            return new ExtractorItemModel(nameof(DouyinExtractor), 
                ((result["item_list"] as JArray)[0]["video"]["cover"]["url_list"] as JArray)[0].ToString(),
                url,
                (result["item_list"] as JArray)[0]["video"]["vid"].ToString(),
                ((result["item_list"] as JArray)[0]["video"]["play_addr"]["url_list"] as JArray)[0].ToString().Replace("playwm/", "play/"));
        }

        public override async Task<List<ExtractorItemModel>> GetUserPost(string url)
        {
            return await GetUserPost(url, "0", string.Empty, string.Empty);
        }

        public async Task<List<ExtractorItemModel>> GetUserPost(string url, string maxCursor, string signature, string userAgent)
        {
            var userId = GetIdFromUrl(url, 3);

            if (string.IsNullOrEmpty(signature))
            {
                (signature, userAgent) = await GetSignatureFromApi(userId);
            }

            var _params = new
            {
                user_id = userId,
                sec_uid = "",
                count = 21,
                max_cursor = maxCursor,
                aid = 1128,
                _signature = signature
            };

            var result = await HttpGet<JObject>("https://www.douyin.com/web/api/v2/aweme/post/", 
                _params, 
                userAgent: userAgent, 
                contentJson: true);

            var listResult = new List<ExtractorItemModel>();

            foreach (var item in result["aweme_list"] as JArray)
            {
                listResult.Add(new ExtractorItemModel
                {
                    Name = nameof(DouyinExtractor),
                    Vid = item["video"]["vid"].ToString(),
                    Avatar = (item["video"]["cover"]["url_list"] as JArray)[0].ToString(),
                    Id = item["aweme_id"].ToString(),
                    Source = $"https://www.iesdouyin.com/share/video/{item["aweme_id"]}/?mid=6811054943680678669",
                    MusicUrl = string.Empty,
                    VideoUrl = (item["video"]["play_addr"]["url_list"] as JArray)[0].ToString()
                });
            }

            if (result["has_more"] != null && result.Value<bool>("has_more"))
            {
                var listMore = await GetUserPost(url, result["max_cursor"].ToString(), signature, userAgent);

                listResult.AddRange(listMore);
            }

            return listResult;
        }

        public override async Task<List<ExtractorItemModel>> GetChanelPost(string url)
        {
            return await GetChanelPost(url, 0, 0, string.Empty);
        }

        public async Task<List<ExtractorItemModel>> GetChanelPost(string url, int cursor = 0, int lastCount = 0, string signature = "", string userAgent = "")
        {
            var chId = GetIdFromUrl(url, 3);

            if (string.IsNullOrEmpty(signature))
            {
                (signature, userAgent) = await GetSignatureFromApi($"{chId}{9}{cursor}");
            }

            var _params = new
            {
                ch_id = chId,
                count = 9,
                cursor = cursor,
                aid = 1128,
                screen_limit = 3,
                download_click_limit = 0,
                _signature = signature
            };

            var result = await HttpGet<JObject>("https://www.iesdouyin.com/web/api/v2/challenge/aweme/",
                _params,
                userAgent: userAgent,
                contentJson: true);

            var listResult = new List<ExtractorItemModel>();

            var count = (result["aweme_list"] as JArray).Count;

            foreach (var item in result["aweme_list"] as JArray)
            {
                listResult.Add(new ExtractorItemModel
                {
                    Name = nameof(DouyinExtractor),
                    Vid = item["video"]["vid"].ToString(),
                    Avatar = (item["video"]["cover"]["url_list"] as JArray)[0].ToString(),
                    Id = item["aweme_id"].ToString(),
                    Source = $"https://www.iesdouyin.com/share/video/{item["aweme_id"]}/?mid=6811054943680678669",
                    MusicUrl = item["music"]["play_url"]["uri"].ToString(),
                    VideoUrl = (item["video"]["play_addr"]["url_list"] as JArray)[0].ToString().Replace("playwm/", "play/")
                });
            }

            if (result["has_more"] != null && result.Value<bool>("has_more") && (lastCount == 0 || count == lastCount))
            {
                var listMore = await GetChanelPost(url, result.Value<int>("cursor") + 9, count, signature, userAgent);

                listResult.AddRange(listMore);
            }

            return listResult;
        }

        protected async Task<(string, string)> GetSignatureFromApi(string str, int @try = 1)
        {
            var signature = string.Empty;
            var userAgent = string.Empty;

            try
            {
                var jData = await HttpPost<JObject>(webConfig.Value.DouyinSignatureApi, new { url = str }, contentJson: true);

                signature = jData["signature"].ToString();
                userAgent = jData["userAgent"].ToString();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetSignatureFromApi|{ex.Message}|{ex.StackTrace}");
            }

            if (string.IsNullOrEmpty(signature) && @try <= 5)
            {
                await Task.Delay(1000);

                return await GetSignatureFromApi(str, @try + 1);
            }

            return (signature, userAgent);
        }

        protected async Task<string> GetSignatureFromNodeApi(string str)
        {
            var jData = await HttpPost<JObject>(webConfig.Value.DouyinSignatureNodeApi, str, contentJson: true);

            return jData["signature"].ToString();
        }

        private string GetSignature(string url, string str)
        {
            try
            {
                var processStart = new ProcessStartInfo(webConfig.Value.PythonPath);
                processStart.UseShellExecute = false;
                processStart.RedirectStandardOutput = true;
                processStart.CreateNoWindow = true;
                processStart.WindowStyle = ProcessWindowStyle.Minimized;
                processStart.Arguments = $"{webConfig.Value.PythonSignature} DOUYIN {url} {str}";
                var process = new Process();
                process.StartInfo = processStart;
                process.Start();
                var result = process.StandardOutput.ReadLine();
                process.WaitForExit();
                process.Close();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetSignature|{ex.Message}|{ex.StackTrace}");
                return string.Empty;
            }
        }
    }
}
