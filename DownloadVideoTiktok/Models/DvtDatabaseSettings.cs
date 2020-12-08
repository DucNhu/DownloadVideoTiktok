using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Models
{
    public class DvtDatabaseSettings : IDvtDatabaseSettings
    {
        public string VideoSourceCollectionName { get; set; }
        public string ArticleCollectionName { get; set; }
        public string UserTransactionCollectionName { get; set; }
        public string HistoryDownloadCollectionName { get; set; }
        public string UserReferenceCollectionName { get; set; }
        public string UserPackageCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDvtDatabaseSettings
    {
        string VideoSourceCollectionName { get; set; }
        string ArticleCollectionName { get; set; }
        string UserTransactionCollectionName { get; set; }
        string HistoryDownloadCollectionName { get; set; }
        string UserReferenceCollectionName { get; set; }
        string UserPackageCollectionName { get; set; }
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
