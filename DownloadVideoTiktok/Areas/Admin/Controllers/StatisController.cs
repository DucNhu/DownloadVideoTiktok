using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DownloadVideoTiktok.Models;
using DownloadVideoTiktok.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DownloadVideoTiktok.Areas.Admin.Controllers
{
    public class StatisController : BaseAdminController
    {
        private readonly ILogger<StatisController> _logger;
        private readonly UserService userService;
        private readonly UserTransactionService userTransactionService;
        private readonly UserPackageService userPackageService;
        private readonly HistoryDownloadService historyDownloadService;

        public StatisController(ILogger<StatisController> logger,
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
        public ActionResult StatisRevenue(string type, DateTime? fromDate, DateTime? toDate)
        {
            toDate = toDate ?? DateTime.Now.Date.AddDays(1);

            fromDate = fromDate ?? toDate.Value.AddDays(-7);

            if (type == "WEEK")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy-MM}-01");

                toDate = fromDate.Value.AddMonths(1).AddDays(-1);
            };

            if (type == "MONTH")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy}-01-01");

                toDate = fromDate.Value.AddYears(1).AddDays(-1);
            };

            var list = userPackageService.GetStatis(fromDate, toDate);

            list.ForEach(item => item.Name = item.Date.ToString("dd/MM/yyyy"));

            var result = new List<StatisModel>();

            for (int i = 0; i < (toDate - fromDate).Value.TotalDays; i++)
            {
                var date = fromDate.Value.AddDays(i);

                var dateStr = date.ToString("dd/MM/yyyy");

                var name = dateStr;

                if (type == "WEEK")
                {
                    name = $"Week {ISOWeek.GetWeekOfYear(date)}";
                };

                if (type == "MONTH")
                {
                    name = $"Month {date.Month}";
                };

                if (!result.Any(c => c.Name == name))
                {
                    result.Add(new StatisModel()
                    {
                        Name = name,
                        Total = 0
                    });
                }

                var _statisDate = list.FirstOrDefault(c => c.Name == dateStr);

                if (_statisDate != null)
                {
                    result.ForEach(item =>
                    {
                        if (item.Name == name)
                        {
                            item.Total += _statisDate.Total;
                        }
                    });
                }
            }

            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

        public ActionResult StatisRevenuePackage(string type, DateTime? fromDate, DateTime? toDate)
        {
            toDate = toDate ?? DateTime.Now.Date.AddDays(1);

            fromDate = fromDate ?? toDate.Value.AddDays(-7);

            if (type == "WEEK")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy-MM}-01");

                toDate = fromDate.Value.AddMonths(1).AddDays(-1);
            };

            if (type == "MONTH")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy}-01-01");

                toDate = fromDate.Value.AddYears(1).AddDays(-1);
            };

            var list = userPackageService.GetStatisByPackage(fromDate, toDate);

            return Content(JsonConvert.SerializeObject(list), "application/json");
        }

        public ActionResult StatisDownload(string type, DateTime? fromDate, DateTime? toDate)
        {
            toDate = toDate ?? DateTime.Now.Date.AddDays(1);

            fromDate = fromDate ?? toDate.Value.AddDays(-7);

            if (type == "WEEK")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy-MM}-01");

                toDate = fromDate.Value.AddMonths(1).AddDays(-1);
            };

            if (type == "MONTH")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy}-01-01");

                toDate = fromDate.Value.AddYears(1).AddDays(-1);
            };

            var list = historyDownloadService.GetStatis(fromDate, toDate);

            list.ForEach(item => item.Name = item.Date.ToString("dd/MM/yyyy"));

            var result = new List<StatisModel>();

            for (int i = 0; i < (toDate - fromDate).Value.TotalDays; i++)
            {
                var date = fromDate.Value.AddDays(i);

                var dateStr = date.ToString("dd/MM/yyyy");

                var name = dateStr;

                if (type == "WEEK")
                {
                    name = $"Week {ISOWeek.GetWeekOfYear(date)}";
                };

                if (type == "MONTH")
                {
                    name = $"Month {date.Month}";
                };

                if (!result.Any(c => c.Name == name))
                {
                    result.Add(new StatisModel()
                    {
                        Name = name,
                        Total = 0
                    });
                }

                var _statisDate = list.FirstOrDefault(c => c.Name == dateStr);

                if (_statisDate != null)
                {
                    result.ForEach(item =>
                    {
                        if (item.Name == name)
                        {
                            item.Total += _statisDate.Total;
                        }
                    });
                }
            }

            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

        public ActionResult StatisUser(string type, DateTime? fromDate, DateTime? toDate)
        {
            toDate = toDate ?? DateTime.Now.Date.AddDays(1);

            fromDate = fromDate ?? toDate.Value.AddDays(-7);

            if (type == "WEEK")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy-MM}-01");

                toDate = fromDate.Value.AddMonths(1).AddDays(-1);
            };

            if (type == "MONTH")
            {
                fromDate = DateTime.Parse($"{DateTime.Now:yyyy}-01-01");

                toDate = fromDate.Value.AddYears(1).AddDays(-1);
            };

            var list = userService.GetStatis(fromDate, toDate);

            list.ForEach(item => item.Name = item.Date.ToString("dd/MM/yyyy"));

            var result = new List<StatisModel>();

            for (int i = 0; i < (toDate - fromDate).Value.TotalDays; i++)
            {
                var date = fromDate.Value.AddDays(i);

                var dateStr = date.ToString("dd/MM/yyyy");

                var name = dateStr;

                if (type == "WEEK")
                {
                    name = $"Week {ISOWeek.GetWeekOfYear(date)}";
                };

                if (type == "MONTH")
                {
                    name = $"Month {date.Month}";
                };

                if (!result.Any(c => c.Name == name))
                {
                    result.Add(new StatisModel()
                    {
                        Name = name,
                        Total = 0
                    });
                }

                var _statisDate = list.FirstOrDefault(c => c.Name == dateStr);

                if (_statisDate != null)
                {
                    result.ForEach(item =>
                    {
                        if (item.Name == name)
                        {
                            item.Total += _statisDate.Total;
                        }
                    });
                }
            }

            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
    }
}
