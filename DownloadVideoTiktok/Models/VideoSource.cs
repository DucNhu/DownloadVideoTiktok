using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Models
{
    public class VideoSource
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public DateTime? DateCreated { get; set; }

        public string UrlCheckLink { get; set; }

        public string UrlCheckUser { get; set; }

        public string UrlCheckChanel { get; set; }

        public string UrlCheckPlaylist { get; set; }

        public int? HasLink { get; set; }

        public int? HasUser { get; set; }

        public int? HasChanel { get; set; }

        public int? HasPlaylist { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
