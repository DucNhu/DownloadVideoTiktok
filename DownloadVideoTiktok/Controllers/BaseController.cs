using DownloadVideoTiktok.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Security.Claims;

namespace DownloadVideoTiktok.Controllers
{
    [TypeFilter(typeof(ActivityActionFilter))]
    public class BaseController : Controller
    {
        public string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public bool IsCheckReCaptcha { 
            get {

                try
                {
                    var response = Request.Form["g-recaptcha-response"];

                    using (var client = new WebClient())
                    {
                        var reply = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret=6LcGQvkUAAAAAEXpl75Ut6t8LStT-nmiasomQEuP&response={response}");

                        var jData = JsonConvert.DeserializeObject<JObject>(reply);

                        return jData != null && jData["success"] != null && Convert.ToBoolean(jData["success"].ToString());
                    }
                }
                catch (Exception)
                {
                    return false;
                }                
            }
        }
    }
}
