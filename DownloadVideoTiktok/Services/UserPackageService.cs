using DownloadVideoTiktok.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Services
{
    public class UserPackageService
    {
        private readonly IMongoCollection<UserPackage> _userPackage;

        public UserPackageService(IDvtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _userPackage = database.GetCollection<UserPackage>(settings.UserPackageCollectionName);
        }

        public List<StatisModel> GetStatisByPackage(DateTime? fromDate, DateTime? toDate)
        {
            var query = _userPackage.AsQueryable().Where(c => c.IsDeleted == false);

            if (fromDate.HasValue) query = query.Where(c => c.DateCreated >= fromDate);
            if (toDate.HasValue) query = query.Where(c => c.DateCreated <= toDate);

            return query.GroupBy(c => c.Package).Select(c => new StatisModel
            {
                Name = c.Key,
                Total = c.Sum(c => c.Cost) ?? 0
            }).ToList();
        }

        public List<StatisModel> GetStatis(DateTime? fromDate, DateTime? toDate)
        {
            var query = _userPackage.AsQueryable().Where(c => c.IsDeleted == false);

            if (fromDate.HasValue) query = query.Where(c => c.DateCreated >= fromDate);
            if (toDate.HasValue) query = query.Where(c => c.DateCreated <= toDate);

            return query.GroupBy(c => new DateTime(c.DateCreated.Value.Year, c.DateCreated.Value.Month, c.DateCreated.Value.Day)).Select(c => new StatisModel
            {
                Date = c.Key,
                Total = c.Sum(c => c.Cost) ?? 0
            }).ToList();
        }

        public double TotalRevenue()
        {
            return _userPackage.AsQueryable().Where(c => c.IsDeleted == false).Sum(c => c.Cost) ?? 0.0;
        }

        public long TotalActive()
        {
            return _userPackage.Find(c => c.IsDeleted == false).CountDocuments();
        }

        public DateTime? GetDateExpiredUser(string userId) => _userPackage.AsQueryable().Where(c => c.UserId == userId
            && c.IsActive == true
            && c.IsDeleted == false)
                .OrderByDescending(c => c.DateExpired)
                .FirstOrDefault()?.DateExpired;

        public List<UserPackage> GetByUser(string userId)
        {
            return _userPackage.Find(c => c.UserId == userId).ToList();
        }

        public (List<UserPackage>, long) Get(string keyword, int skip, int limit)
        {
            var list = _userPackage.Find(c => c.UserId.Contains(keyword) || c.Package.Contains(keyword)).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _userPackage.Find(c => c.UserId.Contains(keyword) || c.Package.Contains(keyword)).CountDocuments();

            return (list, total);
        }

        public List<UserPackage> Get() =>
            _userPackage.Find(c => true).ToList();

        public UserPackage Get(string id) =>
            _userPackage.Find(c => c.Id == id).FirstOrDefault();

        public UserPackage Create(UserPackage userPackage)
        {
            _userPackage.InsertOne(userPackage);
            return userPackage;
        }

        public void Update(string id, UserPackage userPackageIn) =>
            _userPackage.ReplaceOne(c => c.Id == id, userPackageIn);

        public void Remove(UserPackage userPackageIn) =>
            _userPackage.DeleteOne(c => c.Id == userPackageIn.Id);

        public void Remove(string id) =>
            _userPackage.DeleteOne(c => c.Id == id);
    }
}
