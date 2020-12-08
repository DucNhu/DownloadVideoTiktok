using DownloadVideoTiktok.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IDvtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<StatisModel> GetStatis(DateTime? fromDate, DateTime? toDate)
        {
            var query = _users.AsQueryable().Where(c => c.IsDeleted == false);

            if (fromDate.HasValue) query = query.Where(c => c.DateCreated >= fromDate);
            if (toDate.HasValue) query = query.Where(c => c.DateCreated <= toDate);

            return query.GroupBy(c => new DateTime(c.DateCreated.Value.Year, c.DateCreated.Value.Month, c.DateCreated.Value.Day)).Select(c => new StatisModel
            {
                Date = c.Key,
                Total = c.Count()
            }).ToList();
        }

        public long TotalUser()
        {
            return _users.Find(c => c.IsDeleted == false).CountDocuments();
        }

        public User GetByUsername(string username) =>
            _users.Find(user => user.Username == username).FirstOrDefault();

        public (List<User>, long) Get(string keyword, int skip, int limit)
        {
            var list = _users.Find(c => c.Id.Contains(keyword) || c.Username.Contains(keyword) || c.Id.Contains(keyword)).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _users.Find(c => c.Id.Contains(keyword) || c.Username.Contains(keyword) || c.Id.Contains(keyword)).CountDocuments();

            return (list, total);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find(user => user.Id == id).FirstOrDefault();

        public bool CheckUserExisted(string username) =>
            _users.CountDocuments(user => user.Username == username ) > 0;

        public User GetByAuth(string username, string password) =>
            _users.Find(user => user.Username == username && user.Password == password).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}
