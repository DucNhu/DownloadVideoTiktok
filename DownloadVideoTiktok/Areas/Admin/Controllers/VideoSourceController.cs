using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DownloadVideoTiktok.Infrastructure;
using DownloadVideoTiktok.Infrastructure.Extensions;
using DownloadVideoTiktok.Infrastructure.Extractor;
using DownloadVideoTiktok.Models;
using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DownloadVideoTiktok.Areas.Admin.Controllers
{    
    public class VideoSourceController : BaseAdminController
    {
        private readonly ILogger<VideoSourceController> _logger;
        private readonly VideoSourceService service;
        private readonly FileUtility fileUtility;
        private readonly IServiceProvider serviceProvider;

        public VideoSourceController(ILogger<VideoSourceController> logger,
            VideoSourceService service,
            FileUtility fileUtility, 
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.service = service;
            this.fileUtility = fileUtility;
            this.serviceProvider = serviceProvider;
        }

        // GET: VideoSourceController
        public ActionResult Index()
        {
            var pageSize = !string.IsNullOrEmpty(Request.Query["pageSize"]) ? int.Parse(Request.Query["pageSize"]) : 10;
            var page = !string.IsNullOrEmpty(Request.Query["page"]) ? int.Parse(Request.Query["page"]) : 1;
            var keyword = !string.IsNullOrEmpty(Request.Query["keyword"]) ? Request.Query["keyword"].ToString() : string.Empty;

            (var list, var total) = service.Get(keyword, (page - 1) * pageSize, pageSize);

            var model = new PageListModel<VideoSource>
            {
                List = list,
                Total = total,
                PageSize = 10,
                CurrentPage = page
            };

            return View(model);
        }

        public async Task<ActionResult> CheckSource(string source)
        {          
            (var list, var total) = service.Get(string.IsNullOrEmpty(source) ? string.Empty : source, 0, 100);

            foreach (var item in list)
            {
                var _typeService = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => typeof(BaseExtractor).IsAssignableFrom(p)
                    && p.Name.ToLower().Contains(item.Name.ToLower())).FirstOrDefault();

                var serviceExtractor = (BaseExtractor)serviceProvider.GetService(_typeService);

                if (item.HasLink.Value != (int)WebEnums.StatusVideoSource.NO_SUPPORT)
                {
                    var listVideos = await serviceExtractor.ExtractorVideos(item.UrlCheckLink);

                    item.HasLink = listVideos != null && listVideos.Count > 0 ? (int)WebEnums.StatusVideoSource.RUNNING : (int)WebEnums.StatusVideoSource.ERROR;
                }

                if (item.HasUser.Value != (int)WebEnums.StatusVideoSource.NO_SUPPORT)
                {
                    var listVideos = await serviceExtractor.ExtractorVideos(item.UrlCheckUser);

                    item.HasUser = listVideos != null && listVideos.Count > 0 ? (int)WebEnums.StatusVideoSource.RUNNING : (int)WebEnums.StatusVideoSource.ERROR;
                }

                if (item.HasChanel.Value != (int)WebEnums.StatusVideoSource.NO_SUPPORT)
                {
                    var listVideos = await serviceExtractor.ExtractorVideos(item.UrlCheckChanel);

                    item.HasChanel = listVideos != null && listVideos.Count > 0 ? (int)WebEnums.StatusVideoSource.RUNNING : (int)WebEnums.StatusVideoSource.ERROR;
                }

                if (item.HasPlaylist.Value != (int)WebEnums.StatusVideoSource.NO_SUPPORT)
                {
                    var listVideos = await serviceExtractor.ExtractorVideos(item.UrlCheckPlaylist);

                    item.HasPlaylist = listVideos != null && listVideos.Count > 0 ? (int)WebEnums.StatusVideoSource.RUNNING : (int)WebEnums.StatusVideoSource.ERROR;
                }

                service.Update(item.Id, item);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: VideoSourceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VideoSourceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoSourceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoSource model)
        {
            try
            {
                model.DateCreated = DateTime.Now;
                model.IsDeleted = false;

                service.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoSourceController/Edit/5
        public ActionResult Edit(string id)
        {
            var VideoSource = service.Get(id);

            return View(VideoSource);
        }

        // POST: VideoSourceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var VideoSource = service.Get(id);

                VideoSource.Name = collection["Name"];
                VideoSource.HasUser = Convert.ToInt32(collection["HasUser"]);
                VideoSource.HasPlaylist = Convert.ToInt32(collection["HasPlaylist"]);
                VideoSource.HasLink = Convert.ToInt32(collection["HasLink"]);
                VideoSource.HasChanel = Convert.ToInt32(collection["HasChanel"]);
                VideoSource.UrlCheckChanel = collection["UrlCheckChanel"];
                VideoSource.UrlCheckLink = collection["UrlCheckLink"];
                VideoSource.UrlCheckPlaylist = collection["UrlCheckPlaylist"];
                VideoSource.UrlCheckUser = collection["UrlCheckUser"];
                VideoSource.IsActive = Convert.ToBoolean(collection["IsActive"]);

                service.Update(id, VideoSource);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoSourceController/Delete/5
        public ActionResult Delete(string id)
        {
            var videoSource = service.Get(id);

            return View(videoSource);
        }

        // POST: VideoSourceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                service.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
