using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure
{
    public class WebConfig
    {
        public string PythonPath { get; set; }
        public string PythonSignature { get; set; }
        public string PaypalClientId { get; set; }
        public string PaypalSecret { get; set; }
        public string PaypalUrlToken { get; set; }
        public string PaypalUrlCaptureOrder { get; set; }
        public string PaypalUrlCreateOrder { get; set; }
        public string TiktokSignatureApi { get; set; }
        public string TiktokSignatureNodeApi { get; set; }
        public string DouyinSignatureApi { get; set; }
        public string DouyinSignatureNodeApi { get; set; }
        public string PathSaveUploadImage { get; set; }
        public int MinuteExpiredSession { get; set; }
    }
}
