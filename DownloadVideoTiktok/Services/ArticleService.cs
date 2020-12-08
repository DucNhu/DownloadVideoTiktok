using DownloadVideoTiktok.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Services
{
    public class ArticleService
    {
        private readonly IMongoCollection<Article> _article;

        public ArticleService(IDvtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _article = database.GetCollection<Article>(settings.UserCollectionName);
        }

        public Article GetByAscii(string ascii) =>
            _article.Find(c => c.Ascii == ascii).FirstOrDefault();

        public Article GetByCode(string code) =>
            _article.Find(c => c.Code == code).FirstOrDefault();

        public (List<Article>, long) GetByType(string typeCode, int skip, int limit)
        {
            var list = _article.Find(c => c.TypeCode == typeCode).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _article.Find(c => c.TypeCode == typeCode).CountDocuments();

            return (list, total);
        }

        public (List<Article>, long) Get(string keyword, int skip, int limit)
        {
            var list = _article.Find(c => c.Name.Contains(keyword) || c.Ascii.Contains(keyword)).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _article.Find(c => c.Name.Contains(keyword) || c.Ascii.Contains(keyword)).CountDocuments();

            return (list, total);
        }

        public List<Article> Get() =>
            _article.Find(c => true).ToList();

        public Article Get(string id) =>
            _article.Find(c => c.Id == id).FirstOrDefault();

        public Article Create(Article item)
        {
            _article.InsertOne(item);
            return item;
        }

        public void Update(string id, Article itemIn) =>
            _article.ReplaceOne(c => c.Id == id, itemIn);

        public void Remove(Article itemIn) =>
            _article.DeleteOne(c => c.Id == itemIn.Id);

        public void Remove(string id) =>
            _article.DeleteOne(c => c.Id == id);
    }
}
