using DownloadVideoTiktok.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace DownloadVideoTiktok.Infrastructure.Extractor
{
    [ExtractorVideo("youtube")]
    public class YoutubeExtractor : BaseExtractor
    {
        private readonly ILogger<YoutubeExtractor> _logger;
        private readonly IOptions<WebConfig> webConfig;
        private readonly INodeServices nodeServices;

        public YoutubeExtractor(IOptions<WebConfig> _webConfig,
            ILogger<YoutubeExtractor> logger,
            INodeServices nodeServices)
        {
            webConfig = _webConfig;
            _logger = logger;
            this.nodeServices = nodeServices;
        }

        public override WebEnums.TypeUrl CheckTypeUrl(string url)
        {
            var _uri = new Uri(url);

            if (_uri.Segments.Length > 1 && _uri.Segments[1] == "playlist") return WebEnums.TypeUrl.PLAYLIST;

            if (_uri.Segments.Length > 1 && _uri.Segments[1] == "channel/") return WebEnums.TypeUrl.CHANEL;

            return WebEnums.TypeUrl.VIDEO;
        }

        public override async Task<ExtractorItemModel> GetVideo(string url)
        {
            try
            {
                var youtube = new YoutubeClient();

                var video = await youtube.Videos.GetAsync(url);

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id.Value);

                var streamInfo = streamManifest.GetVideo().Where(s => s.Container == Container.Mp4).WithHighestVideoQuality();

                var list = streamManifest.GetMuxed().ToList();

                return new ExtractorItemModel(nameof(YoutubeExtractor), video.Thumbnails.StandardResUrl, url, video.Id.Value, streamInfo.Url);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override async Task<List<ExtractorItemModel>> GetChanelPost(string url)
        {
            var listResults = new List<ExtractorItemModel>();

            var _chId = GetIdFromUrl(url, 2);

            var youtube = new YoutubeClient();

            await foreach (var video in youtube.Channels.GetUploadsAsync(_chId))
            {
                listResults.Add(new ExtractorItemModel()
                {
                    Name = nameof(YoutubeExtractor),
                    Avatar = video.Thumbnails.StandardResUrl,
                    Source = video.Url,
                    Vid = video.Id.Value,
                    VideoUrl = video.Url
                });
            }

            return listResults;
        }

        public override async Task<List<ExtractorItemModel>> GetPlaylistPost(string url)
        {
            var playListId = GetIdFromUrl(url, queryparam: "list");

            var listResults = new List<ExtractorItemModel>();

            var youtube = new YoutubeClient();

            var playlist = await youtube.Playlists.GetAsync(playListId);

            await foreach (var video in youtube.Playlists.GetVideosAsync(playlist.Id))
            {
                listResults.Add(new ExtractorItemModel()
                {
                    Name = "Youtube",
                    Avatar = video.Thumbnails.StandardResUrl,
                    Source = video.Url,
                    Vid = video.Id.Value,
                    VideoUrl = video.Url
                });
            }

            return listResults;
        }
    }
}
