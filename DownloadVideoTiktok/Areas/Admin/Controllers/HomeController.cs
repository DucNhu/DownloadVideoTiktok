using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DownloadVideoTiktok.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService userService;
        private readonly UserTransactionService userTransactionService;
        private readonly UserPackageService userPackageService;
        private readonly HistoryDownloadService historyDownloadService;

        public HomeController(ILogger<HomeController> logger,
            UserService userService, 
            UserTransactionService userTransactionService, 
            UserPackageService userPackageService, 
            HistoryDownloadService historyDownloadService)
        {
            _logger = logger;
            this.userService = userService;
            this.userTransactionService = userTransactionService;
            this.userPackageService = userPackageService;
            this.historyDownloadService = historyDownloadService;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            ViewBag.TotalUser = userService.TotalUser();
            ViewBag.TotalDownload = historyDownloadService.TotalDownload();
            ViewBag.TotalPackageActive = userPackageService.TotalActive();
            ViewBag.TotalRevenue = userPackageService.TotalRevenue();

            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
