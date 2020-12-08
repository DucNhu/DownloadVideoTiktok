using System;

namespace DownloadVideoTiktok.Models
{
    public class ExtractorItemModel
    {
        public ExtractorItemModel()
        {

        }

        public ExtractorItemModel(string name, string avatar, string source, string vid, string videoUrl)
        {
            Name = name;
            Avatar = avatar;
            Source = source;
            Vid = vid;
            VideoUrl = videoUrl;
        }

        public ExtractorItemModel(string name, string avatar, string source, string vid, string videoUrl, string musicUrl)
        {
            Name = name;
            Avatar = avatar;
            Source = source;
            Vid = vid;
            VideoUrl = videoUrl;
            MusicUrl = musicUrl;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Source { get; set; }
        public string RequestSource { get; set; }
        public string Resolution { get; set; }
        public string[] ResolutionArray { get; set; }
        public string Vid { get; set; }
        public string VideoUrl { get; set; }
        public string MusicUrl { get; set; }
        public string LinkDownloadVideo { get; set; }
        public string LinkDownloadMusic { get; set; }
        public bool Status => !string.IsNullOrEmpty(Avatar);
    }
}
