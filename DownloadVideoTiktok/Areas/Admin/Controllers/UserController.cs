using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DownloadVideoTiktok.Models;
using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DownloadVideoTiktok.Areas.Admin.Controllers
{    
    public class UserController : BaseAdminController
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService userService;

        public UserController(ILogger<UserController> logger,
            UserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        // GET: ArticleController
        public ActionResult Index()
        {
            var pageSize = !string.IsNullOrEmpty(Request.Query["pageSize"]) ? int.Parse(Request.Query["pageSize"]) : 10;
            var page = !string.IsNullOrEmpty(Request.Query["page"]) ? int.Parse(Request.Query["page"]) : 1;
            var keyword = !string.IsNullOrEmpty(Request.Query["keyword"]) ? Request.Query["keyword"].ToString() : string.Empty;

            (var list, var total) = userService.Get(keyword, (page - 1) * pageSize, pageSize);

            var model = new PageListModel<User>
            {
                List = list,
                Total = total,
                PageSize = 10,
                CurrentPage = page
            };

            return View(model);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(string id)
        {
            var item = userService.Get(id);

            return View(item);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
