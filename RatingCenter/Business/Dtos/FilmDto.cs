using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class FilmDto
    {
        public string Id { get; set; }
        
        public string Url { get; set; }

        public int EpisodeId { get; set; }

        public string Title { get; set; }

        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
