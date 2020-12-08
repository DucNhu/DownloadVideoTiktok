using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Models
{
    public class UserTransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Type { get; set; }

        public string TransactionId { get; set; }

        public string ReferenceCode { get; set; }

        public double? Cost { get; set; }

        public bool? IsPlus { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
