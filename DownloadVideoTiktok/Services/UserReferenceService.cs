using DownloadVideoTiktok.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Services
{
    public class UserReferenceService
    {
        private readonly IMongoCollection<UserReference> _userReferences;

        public UserReferenceService(IDvtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _userReferences = database.GetCollection<UserReference>(settings.UserReferenceCollectionName);
        }

        public (List<UserReference>, long) GetByUser(string userId, int skip, int limit)
        {
            var list = _userReferences.Find(c => c.UserId == userId).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _userReferences.Find(c => c.UserId == userId).CountDocuments();

            return (list, total);
        }

        public List<UserReference> Get() =>
            _userReferences.Find(userReference => true).ToList();

        public UserReference Get(string id) =>
            _userReferences.Find(userReference => userReference.Id == id).FirstOrDefault();

        public UserReference Create(UserReference userReference)
        {
            _userReferences.InsertOne(userReference);
            return userReference;
        }

        public void Update(string id, UserReference userReferenceIn) =>
            _userReferences.ReplaceOne(userReference => userReference.Id == id, userReferenceIn);

        public void Remove(UserReference userReferenceIn) =>
            _userReferences.DeleteOne(userReference => userReference.Id == userReferenceIn.Id);

        public void Remove(string id) =>
            _userReferences.DeleteOne(userReference => userReference.Id == id);
    }
}
