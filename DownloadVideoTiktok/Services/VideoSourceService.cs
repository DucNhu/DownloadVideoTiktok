using DownloadVideoTiktok.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Services
{
    public class VideoSourceService
    {
        private readonly IMongoCollection<VideoSource> _collection;

        public VideoSourceService(IDvtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<VideoSource>(settings.VideoSourceCollectionName);
        }

        public (List<VideoSource>, long) Get(string keyword, int skip, int limit)
        {
            var list = _collection.Find(c => c.Name.Contains(keyword)).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _collection.Find(c => c.Name.Contains(keyword)).CountDocuments();

            return (list, total);
        }

        public List<VideoSource> Get() =>
            _collection.Find(c => true).ToList();

        public VideoSource Get(string id) =>
            _collection.Find(c => c.Id == id).FirstOrDefault();

        public VideoSource Create(VideoSource item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public void Update(string id, VideoSource itemIn) =>
            _collection.ReplaceOne(c => c.Id == id, itemIn);

        public void Remove(VideoSource itemIn) =>
            _collection.DeleteOne(c => c.Id == itemIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(c => c.Id == id);
    }
}
