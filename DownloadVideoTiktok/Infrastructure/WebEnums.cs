using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure
{
    public static class WebEnums
    {
        public enum TypeUrl
        {
            VIDEO,
            USER,
            CHANEL,
            PLAYLIST,
            HASHTAG
        }

        public enum StatusVideoSource : int
        {
            NO_SUPPORT = 0,
            RUNNING = 1,
            ERROR = 2
        }
    }
}
