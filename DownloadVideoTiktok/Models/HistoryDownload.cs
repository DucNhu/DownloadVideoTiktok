using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Models
{
    public class HistoryDownload
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string RequestId { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Source { get; set; }

        public string Link { get; set; }

        public string RequestLink { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DateCreated { get; set; }

        public bool? IsVipRequset { get; set; }

        public bool? IsDownload { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
