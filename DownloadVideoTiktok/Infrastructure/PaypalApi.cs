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
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure
{
    public class PaypalApi
    {
        private readonly ILogger<PaypalApi> _logger;
        private readonly IOptions<WebConfig> webConfig;

        public PaypalApi(IOptions<WebConfig> _webConfig,
            ILogger<PaypalApi> logger)
        {
            webConfig = _webConfig;
            _logger = logger;
        }

        public async Task<string> GetOrderId(object dataOrder)
        {
            var data = await GetApi(webConfig.Value.PaypalUrlCreateOrder, dataOrder);

            return JObject.FromObject(data)["id"].ToString();
        }

        public async Task<object> CaptureOrder(string orderId)
        {
            return await GetApi($"{webConfig.Value.PaypalUrlCaptureOrder}/{orderId}/capture", null);
        }

        protected async Task<JObject> GetApi(string url, object @params)
        {
            var jData = new JObject();

            try
            {
                using (var client = new HttpClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");

                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {await GetToken()}");

                    var content = new StringContent(@params != null ? JsonConvert.SerializeObject(@params) : string.Empty);

                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

                    using (var res = await client.PostAsync(url, content))
                    {
                        var _strRes = await res.Content.ReadAsStringAsync();

                        if (res.IsSuccessStatusCode)
                        {     
                            jData = JObject.Parse(_strRes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetApi));
                jData["statusCode"] = "1";
                jData["mesage"] = ex.Message;
            }

            return jData;
        }

        protected async Task<string> GetToken()
        {
            var token = string.Empty;

            try
            {
                using (var client = new HttpClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded");

                    var authToken = Encoding.ASCII.GetBytes($"{webConfig.Value.PaypalClientId}:{webConfig.Value.PaypalSecret}");

                    client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(authToken)}");

                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials")
                    });

                    using (var res = await client.PostAsync(webConfig.Value.PaypalUrlToken, content))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            var jData = JObject.Parse(await res.Content.ReadAsStringAsync());

                            token = jData["access_token"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetToken));
            }

            return token;
        }
    }
}
