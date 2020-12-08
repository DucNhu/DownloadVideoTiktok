using DownloadVideoTiktok.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Services
{
    public class HistoryDownloadService
    {
        private readonly IMongoCollection<HistoryDownload> _historyDownload;

        public HistoryDownloadService(IDvtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _historyDownload = database.GetCollection<HistoryDownload>(settings.HistoryDownloadCollectionName);
        }

        public List<StatisModel> GetStatis(DateTime? fromDate, DateTime? toDate)
        {
            var query = _historyDownload.AsQueryable().Where(c => c.IsDeleted == false);

            if (fromDate.HasValue) query = query.Where(c => c.DateCreated >= fromDate);
            if (toDate.HasValue) query = query.Where(c => c.DateCreated <= toDate);

            return query.GroupBy(c => new DateTime(c.DateCreated.Value.Year, c.DateCreated.Value.Month, c.DateCreated.Value.Day)).Select(c => new StatisModel
            {
                Date = c.Key,
                Total = c.Count()
            }).ToList();
        }

        public long TotalDownload()
        {
            return _historyDownload.Find(c => c.IsDeleted == false).CountDocuments();
        }

        public int CountVip(string userId, DateTime? fromDate, DateTime? toDate, bool? isVipRequest)
        {
            var query = _historyDownload.AsQueryable().Where(c => c.IsDeleted == false);

            if (!string.IsNullOrEmpty(userId)) query = query.Where(c => c.UserId == userId);
            if (fromDate.HasValue) query = query.Where(c => c.DateCreated >= fromDate);
            if (toDate.HasValue) query = query.Where(c => c.DateCreated <= toDate);
            if (isVipRequest.HasValue) query = query.Where(c => c.IsVipRequset == isVipRequest);

            return query.GroupBy(c => c.RequestId).Count();
        }

        public (List<HistoryDownload>, long) GetByUser(string userId, int skip, int limit) 
        {
            var list = _historyDownload.Find(c => c.UserId == userId).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _historyDownload.Find(c => c.UserId == userId).CountDocuments();

            return (list, total);
        }

        public (List<HistoryDownload>, long) GetLinkSource(string keyword, int skip, int limit)
        {
            var query = _historyDownload.AsQueryable()
                .Where(c => c.UserId.Contains(keyword) || c.Name.Contains(keyword) || c.Link.Contains(keyword) || c.Source.Contains(keyword) && c.IsDeleted == false)
                .GroupBy(c => c.RequestLink);

            var list = query.Skip(skip).Take(limit).Select(c => new HistoryDownload { 
                Name = c.First().Name,
                RequestLink = c.Key,
                DateCreated = c.First().DateCreated
            }).ToList();

            var total = query.Count();

            return (list, total);
        }

        public (List<HistoryDownload>, long) Get(string keyword, int skip, int limit)
        {
            var list = _historyDownload.Find(c => c.UserId.Contains(keyword) || c.Name.Contains(keyword) || c.Link.Contains(keyword) || c.Source.Contains(keyword) || c.RequestLink.Contains(keyword)).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _historyDownload.Find(c => c.UserId.Contains(keyword) || c.Name.Contains(keyword) || c.Link.Contains(keyword) || c.Source.Contains(keyword) || c.RequestLink.Contains(keyword)).CountDocuments();

            return (list, total);
        }

        public List<HistoryDownload> Get() =>
            _historyDownload.Find(user => true).ToList();

        public HistoryDownload Get(string id) =>
            _historyDownload.Find(c => c.Id == id).FirstOrDefault();

        public HistoryDownload Create(HistoryDownload historyDownload)
        {
            _historyDownload.InsertOne(historyDownload);
            return historyDownload;
        }

        public void Update(string id, HistoryDownload historyDownloadIn) =>
            _historyDownload.ReplaceOne(c => c.Id == id, historyDownloadIn);

        public void Remove(HistoryDownload historyDownloadIn) =>
            _historyDownload.DeleteOne(c => c.Id == historyDownloadIn.Id);

        public void Remove(string id) =>
            _historyDownload.DeleteOne(c => c.Id == id);
    }
}
