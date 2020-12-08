using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DownloadVideoTiktok.Models;
using System.Net;
using HtmlAgilityPack;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using DownloadVideoTiktok.Services;
using Newtonsoft.Json.Linq;
using DownloadVideoTiktok.Infrastructure;
using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using DownloadVideoTiktok.Infrastructure.Extractor;

namespace DownloadVideoTiktok.Controllers
{
    public class BlogController : BaseController
    {
        private readonly ILogger<BlogController> _logger;
        private readonly ArticleService articleService;

        public BlogController(ILogger<BlogController> logger,
            ArticleService articleService)
        {
            _logger = logger;
            this.articleService = articleService;
        }

        [HttpGet("/blogs")]
        public IActionResult Index()
        {
            var page = !string.IsNullOrEmpty(Request.Query["page"]) ? int.Parse(Request.Query["page"]) : 1;

            (var list, var total) = articleService.GetByType("BLOG", (page - 1) * 10, 10);

            var model = new PageListModel<Article>
            {
                List = list,
                Total = total,
                PageSize = 10,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet("/blogs/{name}")]
        public IActionResult BlogDetail(string name)
        {
            var item = articleService.GetByAscii(name);

            return View(item);
        }        
    }
}
