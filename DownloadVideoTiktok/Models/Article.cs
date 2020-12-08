using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Models
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Ascii { get; set; }

        public string Code { get; set; }

        public string TypeCode { get; set; }

        public string Language { get; set; }

        public string UrlPicture { get; set; }

        public string Summary { get; set; }

        public string Detail { get; set; }

        public string SEOTitle { get; set; }

        public string SEODescrition { get; set; }

        public string SEOKeywords { get; set; }

        public int? DisplayOrder { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
