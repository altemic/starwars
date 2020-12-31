using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Integrations.Dtos
{
    public class FilmDto
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("episode_id")]
        public int EpisodeId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("opening_crawl")]
        public string OpeningCrawl { get; set; }

        [JsonPropertyName("director")]
        public string Director { get; set; }

        [JsonPropertyName("producer")]
        public string Producer { get; set; }

        //TODO: replace with date time
        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        public string Id => Url.Split("/").Last(p => !string.IsNullOrWhiteSpace(p));
    }
}
