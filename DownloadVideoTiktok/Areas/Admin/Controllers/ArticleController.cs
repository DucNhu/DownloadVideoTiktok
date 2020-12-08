using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DownloadVideoTiktok.Infrastructure;
using DownloadVideoTiktok.Infrastructure.Extensions;
using DownloadVideoTiktok.Models;
using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DownloadVideoTiktok.Areas.Admin.Controllers
{    
    public class ArticleController : BaseAdminController
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly ArticleService articleService;
        private readonly FileUtility fileUtility;

        public ArticleController(ILogger<ArticleController> logger,
            ArticleService articleService, 
            FileUtility fileUtility)
        {
            _logger = logger;
            this.articleService = articleService;
            this.fileUtility = fileUtility;
        }

        // GET: ArticleController
        public ActionResult Index()
        {
            var pageSize = !string.IsNullOrEmpty(Request.Query["pageSize"]) ? int.Parse(Request.Query["pageSize"]) : 10;
            var page = !string.IsNullOrEmpty(Request.Query["page"]) ? int.Parse(Request.Query["page"]) : 1;
            var keyword = !string.IsNullOrEmpty(Request.Query["keyword"]) ? Request.Query["keyword"].ToString() : string.Empty;

            (var list, var total) = articleService.Get(keyword, (page - 1) * pageSize, pageSize);

            var model = new PageListModel<Article>
            {
                List = list,
                Total = total,
                PageSize = 10,
                CurrentPage = page
            };

            return View(model);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Article model)
        {
            try
            {
                model.Ascii = model.Name.ToAscii();
                model.DateCreated = DateTime.Now;
				foreach (var file in Request.Form.Files)
                {
                    model.UrlPicture = await fileUtility.SaveFile(file);
                }
                model.IsDeleted = false;

                articleService.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(string id)
        {
            var article = articleService.Get(id);

            return View(article);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, IFormCollection collection)
        {
            try
            {
                var article = articleService.Get(id);

                article.Name = collection["Name"];
                article.Code = collection["Code"];
                article.Language = collection["Language"];
                article.TypeCode = collection["TypeCode"];
                article.IsActive = Convert.ToBoolean(collection["IsActive"]);
                article.DisplayOrder = Convert.ToInt32(collection["DisplayOrder"]);
                article.Summary = collection["Summary"];
                article.Detail = collection["Detail"];
                article.SEOTitle = collection["SEOTitle"];
                article.SEODescrition = collection["SEODescrition"];
                article.SEOKeywords = collection["SEOKeywords"];
                article.Ascii = article.Name.ToAscii();

                foreach (var file in collection.Files)
                {
                    article.UrlPicture = await fileUtility.SaveFile(file);
                }

                articleService.Update(id, article);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(string id)
        {
            var article = articleService.Get(id);

            return View(article);
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                articleService.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
