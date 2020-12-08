using DownloadVideoTiktok.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DownloadVideoTiktok.Infrastructure.Extractor
{
    public class BaseExtractor
    {
        public BaseExtractor()
        {

        }

        public virtual WebEnums.TypeUrl CheckTypeUrl(string url)
        {
            return WebEnums.TypeUrl.VIDEO;
        }

        public virtual async Task<List<ExtractorItemModel>> ExtractorVideos(string url)
        {
            try
            {
                switch (CheckTypeUrl(url))
                {
                    case WebEnums.TypeUrl.VIDEO:
                        return new List<ExtractorItemModel> { await GetVideo(url) };
                    case WebEnums.TypeUrl.USER:
                        return await GetUserPost(url);
                    case WebEnums.TypeUrl.CHANEL:
                        return await GetChanelPost(url);
                    case WebEnums.TypeUrl.PLAYLIST:
                        return await GetPlaylistPost(url);
                    case WebEnums.TypeUrl.HASHTAG:
                        return await GetHashtagPost(url);
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }

            return new List<ExtractorItemModel>();
        }

        public virtual Task<ExtractorItemModel> GetVideo(string url)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<ExtractorItemModel>> GetUserPost(string url)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<ExtractorItemModel>> GetChanelPost(string url)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<ExtractorItemModel>> GetPlaylistPost(string url)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<ExtractorItemModel>> GetHashtagPost(string url)
        {
            throw new NotImplementedException();
        }

        public string GetIdFromUrl(string url, int? segmentIndex = null, string queryparam = "")
        {
            var _uri = new Uri(url);

            if (segmentIndex.HasValue) return _uri.Segments[segmentIndex.Value].Replace("/", string.Empty);

            if (!string.IsNullOrEmpty(queryparam)) return QueryHelpers.ParseQuery(_uri.Query)[queryparam].ToString();

            return string.Empty;
        }

        public string BuildLinkApi(string api, object @params)
        {
            var query = string.Empty;

            if (@params != null)
            {
                foreach (var item in @params.GetType().GetProperties())
                {
                    if (item.GetValue(@params) != null) query += (string.IsNullOrEmpty(query) ? string.Empty : "&") + item.Name + "=" + item.GetValue(@params).ToString();
                }
            }

            return $"{api}?{query}";
        }

        public async Task<T> HttpGet<T>(string url, object @params, string userAgent = "", bool contentJson = false, string referrer = "") where T : class
        {
            url = BuildLinkApi(url, @params);

            return await HttpGet<T>(url, userAgent, contentJson, referrer);
        }

        public async Task<T> HttpGet<T>(string url, string userAgent = "", bool contentJson = false, string referrer = "") where T : class
        {
            return JObject.Parse(await HttpGet(url, userAgent, contentJson, referrer)).ToObject<T>();
        }

        public async Task<string> HttpGet(string url, object @params, string userAgent = null, bool contentJson = false, string referrer = "")
        {
            url = BuildLinkApi(url, @params);

            return await HttpGet(url, userAgent, contentJson, referrer);
        }

        public async Task<string> HttpGet(string url, string userAgent = null, bool contentJson = false, string referrer = "")
        {
            var contentPage = string.Empty;

            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                if (contentJson) client.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");

                if (!string.IsNullOrEmpty(referrer)) client.DefaultRequestHeaders.Referrer = new Uri(referrer);

                if (!string.IsNullOrEmpty(userAgent)) client.DefaultRequestHeaders.Add("User-Agent", userAgent);

                using (var res = await client.GetAsync(url))
                {
                    contentPage = await res.Content.ReadAsStringAsync();
                }
            }

            return contentPage;
        }

        public async Task<T> HttpPost<T>(string url, object dataPost, string userAgent = "", bool contentJson = false) where T : class
        {
            return JObject.Parse(await HttpPost(url, dataPost, userAgent, contentJson)).ToObject<T>();
        }

        public async Task<string> HttpPost(string url, object dataPost, string userAgent = null, bool contentJson = false)
        {
            var contentPage = string.Empty;

            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                if (contentJson) client.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");

                if (!string.IsNullOrEmpty(userAgent)) client.DefaultRequestHeaders.Add("User-Agent", userAgent);

                var content = new StringContent(dataPost.GetType() == typeof(string) ? dataPost.ToString() : JsonConvert.SerializeObject(dataPost));

                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

                using (var res = await client.PostAsync(url, content))
                {
                    contentPage = await res.Content.ReadAsStringAsync();
                }
            }

            return contentPage;
        }
    }
}
