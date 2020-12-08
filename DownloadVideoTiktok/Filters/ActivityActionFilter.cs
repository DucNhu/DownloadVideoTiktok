using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Filters
{
    public class ActivityActionFilter : IActionFilter
    {
        private readonly UserService userService;

        public ActivityActionFilter(UserService userService)
        {
            this.userService = userService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = userService.Get(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

                var token = context.HttpContext.Request.Cookies[".AspNetCore.Cookies"];

                if (!string.IsNullOrEmpty(token) && user.LastToken != token)
                {
                    context.HttpContext.SignOutAsync();

                    context.Result = new RedirectResult("/");
                }
            }            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
