using DownloadVideoTiktok.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Services
{
    public class UserTransactionService
    {
        private readonly IMongoCollection<UserTransaction> _userTransaction;

        public UserTransactionService(IDvtDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _userTransaction = database.GetCollection<UserTransaction>(settings.UserTransactionCollectionName);
        }

        public double GetBalance(string userId)
        {
            var totalIn = _userTransaction.AsQueryable().Where(c => c.UserId == userId && c.IsPlus == true && c.IsActive == true && c.IsDeleted == false).Sum(c => c.Cost) ?? 0;
            var totalOut = _userTransaction.AsQueryable().Where(c => c.UserId == userId && c.IsPlus == false && c.IsActive == true && c.IsDeleted == false).Sum(c => c.Cost) ?? 0;

            return totalIn - totalOut;
        }

        public UserTransaction GetByTransaction(string transaction) =>
            _userTransaction.Find(c => c.TransactionId == transaction).FirstOrDefault();

        public (List<UserTransaction>, long) GetByUser(string userId, int skip, int limit) 
        { 
            var list = _userTransaction.Find(c => c.UserId == userId).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _userTransaction.Find(c => c.UserId == userId).CountDocuments();

            return (list, total);
        }

        public (List<UserTransaction>, long) Get(string keyword, int skip, int limit)
        {
            var list = _userTransaction.Find(c => c.ReferenceCode.Contains(keyword) || c.TransactionId.Contains(keyword) || c.UserId.Contains(keyword)).SortByDescending(c => c.DateCreated).Skip(skip).Limit(limit).ToList();

            var total = _userTransaction.Find(c => c.ReferenceCode.Contains(keyword) || c.TransactionId.Contains(keyword) || c.UserId.Contains(keyword)).CountDocuments();

            return (list, total);
        }

        public List<UserTransaction> Get() =>
            _userTransaction.Find(user => true).ToList();

        public UserTransaction Get(string id) =>
            _userTransaction.Find(c => c.Id == id).FirstOrDefault();

        public UserTransaction Create(UserTransaction UserTransaction)
        {
            _userTransaction.InsertOne(UserTransaction);
            return UserTransaction;
        }

        public void Update(string id, UserTransaction UserTransactionIn) =>
            _userTransaction.ReplaceOne(c => c.Id == id, UserTransactionIn);

        public void Remove(UserTransaction UserTransactionIn) =>
            _userTransaction.DeleteOne(c => c.Id == UserTransactionIn.Id);

        public void Remove(string id) =>
            _userTransaction.DeleteOne(c => c.Id == id);
    }
}
