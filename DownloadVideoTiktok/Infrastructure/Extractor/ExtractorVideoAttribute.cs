using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure.Extractor
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExtractorVideoAttribute : Attribute
    {
        public string Host { get; set; }

        public ExtractorVideoAttribute(string host)
        {
            Host = host;
        }
    }
}
