using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Models
{
    public class StatisModel
    {
        public string Name { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
    }
}
